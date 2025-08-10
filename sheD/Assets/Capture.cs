using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capture : MonoBehaviour
{
    [SerializeField] private GameObject deadParticle;
    [SerializeField] private Transform deadParticleTransform;
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
        //Desabilito controles
        _input.SetInputActive(false);
        
        //Zoom dramático
        
        
        //Animación de sorpresa
        _animationController.SetOnCapture();
        var instance = Instantiate(deadParticle, deadParticleTransform.position, Quaternion.identity, deadParticleTransform);
        
        
        
        //TimeScale =0
        //Serpentina estrangulada
        
        //Go to main menu
        
        
        StartCoroutine((EndGame()));
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
