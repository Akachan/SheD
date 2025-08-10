using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using FMOD.Studio;
using STOP_MODE = FMOD.Studio.STOP_MODE;


public class SnakeSound : MonoBehaviour
{
    [SerializeField] private EventReference eatSfx;
    [SerializeField] private EventReference hide;
    [SerializeField] private EventReference moveSfx;

    [SerializeField] private GameObject player;

    //Declaraciónes
    private InputManager _input;
    private EventInstance _hideEventInstance;
    private EventInstance _moveEventInstance;
    private Player _player;

    public void EatSound()
    {
        RuntimeManager.PlayOneShotAttached(eatSfx, player);
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

        RuntimeManager.AttachInstanceToGameObject(_moveEventInstance, player);

    }

    public void Hide()
    {
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
        int state = 0;
        if (_player.IsCamuflaged)
        {
            state = 1;
        }
        else
        {
            state = 0;
        }
        _hideEventInstance.setParameterByName("SnakeState", state);

        float foodAmount = Mathf.Clamp(LevelManager.Instance.CurrentFoodCount / (float)LevelManager.Instance.FoodValueToWin, 0, 1f); ;

        _hideEventInstance.setParameterByName("FoodAmount", foodAmount);

        float foodParameter;
        _hideEventInstance.getParameterByName("FoodAmount", out foodParameter);

        //Debug.Log("Food on FMOD event: " + foodParameter);
        //Debug.Log("Food: " + foodAmount + ". SnakeState: " + state);
    }

    void HandleWalkSound()
    {
        // CODIGO SONIDO DE CAMINAR
        PLAYBACK_STATE state;
        _moveEventInstance.getPlaybackState(out state);
        Debug.Log("State before if " + state);
        if (state == PLAYBACK_STATE.PLAYING && _input.MovementValue == Vector2.zero) // elif is playing and not walking -> stop
        {
            _moveEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
            //_moveEventInstance.release();
        }
        Debug.Log("State after   if " + state);
    }
}
