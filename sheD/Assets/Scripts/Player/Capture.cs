using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Core;
using Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capture : MonoBehaviour
{
    private static readonly int OnStop = Animator.StringToHash("onStop");
    [SerializeField] private GameObject deadParticle;
    private Player _player;
    private InputManager _input;
    private AnimationController _animationController;
    private bool _isDead = false;
    

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _input = GetComponentInParent<InputManager>();
        _animationController = _player.GetComponentInChildren<AnimationController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(_player.IsCamuflaged) {return;}

            GameOver();
        }
    }

    private void GameOver()
    {
        
        
        if (_isDead) return;
        _isDead = true;
        
        //Cambio a música de GameOver
        AudioManager.Instance.SetGameOverBgm();
        
        //Desabilito controles
        _input.SetInputActive(false);
        

        //Animación de sorpresa/ansiedad
        _animationController.SetOnCapture();
        
        //Zoom dramático
        // -> se activó con el estado onCapture

        var current = _player.CurrentVfxPosition;
        //Seteo posición de particulas
        
        var instance = Instantiate(deadParticle, current.VsfTransform.position, Quaternion.identity, current.VsfTransform);
        
        //la flipeo si está mirando a la izq o der
        var scale = instance.transform.localScale;
        scale.x = _player.CurrentVfxPosition.VsfScale;
        instance.transform.localScale = scale;
        
        
        
        //TimeScale =0 -> no sirve hay que parar a los lee (pa mas tarde)
        var lees = FindObjectsOfType<LeeMover>();
        foreach (var lee in lees)
        {
            
            lee.StopLee();
            lee.GetComponentInChildren<Animator>().SetTrigger(OnStop);
        }
        
        //Serpentina estrangulada
        
        //Go to main menu
        
        
        StartCoroutine((LevelManager.Instance.EndGame(EndGameType.Lose)));
    }


}
