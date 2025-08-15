using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using Core;
using FMOD.Studio;
using Food;
using STOP_MODE = FMOD.Studio.STOP_MODE;


public class SnakeSound : MonoBehaviour
{
    [SerializeField] private EventReference eatSfx;
    [SerializeField] private EventReference hide;
    [SerializeField] private EventReference moveSfx;

   

    //Declaraci�nes
    private InputManager _input;
    private EventInstance _hideEventInstance;
    private EventInstance _moveEventInstance;
    private Player _player;

    public void EatSound()
    {
        RuntimeManager.PlayOneShotAttached(eatSfx, _player.gameObject);
    }

    //public void EatTransformSound()
    //{
    //    RuntimeManager.PlayOneShotAttached(eatTransformSfx, player);
    //}


    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _input = FindFirstObjectByType<InputManager>();
    }

    void Start()
    {
        _hideEventInstance = RuntimeManager.CreateInstance(hide);
        _moveEventInstance = RuntimeManager.CreateInstance(moveSfx);

        RuntimeManager.AttachInstanceToGameObject(_moveEventInstance, _player.gameObject);

    }

    public void Hide()
    {
        Debug.Log("Hide");
        _hideEventInstance.start();
    }

    public void Move()
    {
        _moveEventInstance.start();
    }



    private void Update()
    {
        HandleHideSound();
        HandleWalkSound();

    }

    void HandleHideSound()
    {
        //Verifico el estado del player
        int state = 0;
        state = _player.IsCamuflaged ? 1 : 0;
        //Aplico el parametro
        _hideEventInstance.setParameterByName("SnakeState", state);

        //Tomo el ratio del invetario
        var foodRatio = LevelManager.Instance.FoodInventory.GetCamouflageFoodRatio();
        //Aplico el parámetro
        _hideEventInstance.setParameterByName("FoodAmount", foodRatio);
    }

    void HandleWalkSound()
    {
        // CODIGO SONIDO DE CAMINAR
        PLAYBACK_STATE state;
        _moveEventInstance.getPlaybackState(out state);
        //Debug.Log("State before if " + state);
        if (state == PLAYBACK_STATE.PLAYING && _input.MovementValue == Vector2.zero) // elif is playing and not walking -> stop
        {
            _moveEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
            //_moveEventInstance.release();
        }
        //Debug.Log("State after   if " + state);
    }

    
    private void OnDestroy()
    {
        _hideEventInstance.release();
    }
}
