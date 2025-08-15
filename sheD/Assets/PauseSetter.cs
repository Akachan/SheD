using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseSetter : MonoBehaviour
{
    private bool _pauseState;
    private InputManager _input;
    private AudioManager _audioManager;


    private void Awake()
    {
        _input = FindFirstObjectByType<InputManager>();
        _audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void Start()
    {
        _input.OnPauseEvent += SetPause;
        UiManager.Instance.OnRemoveAction += RemovePause;
    }

    private void SetPause()
    {
        _pauseState = true;
        
        //eliminar el evento de poner pausa y agregar evento de quitar pausa
        _input.OnPauseEvent -= SetPause;
        _input.OnPauseEvent += RemovePause;
        
        
        //detener el tiempo
        Time.timeScale = 0f;
        
        //no dejar que el player se mueva
        _input.SetInputActive(false);
        
        //cambiar a la musica de pausa
        _audioManager.SetPauseBgm();


        //aparecer el panel de pausa
        UiManager.Instance.EnablePausePanel();

        //cambiar al mapa de input de UI
        _input.SwitchToUIMap();

     

    }
    
    public void RemovePause()
    {
        if(!_pauseState) return;
        //eliminar el evento de quitar pausa y agregar evento de poner pausa
        _input.OnPauseEvent -= RemovePause;
        _input.OnPauseEvent += SetPause;
        
        //reanudar el tiempo
        Time.timeScale = 1f;
        
        //hacer que el player vuelva a moverse
        _input.SetInputActive(true);
        
        //cambiar a la musica de juego
        _audioManager.RemovePauseBgm();
        
        //ocultar el panel de pausa
        UiManager.Instance.DisablePausePanel();
        
        //cambiar al mapa de input de player
        _input.SwitchToPlayerMap();
    }
    
    
    
    
}
