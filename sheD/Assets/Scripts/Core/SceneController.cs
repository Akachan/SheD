using System;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneController:MonoBehaviour
    {
        private int _currentSceneIndex;
        private AudioManager _audioManager;


        private void Awake()
        {
            _audioManager = FindFirstObjectByType<AudioManager>();
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void Start()
        {
            Debug.Log($"SceneController Start. SceneNumber {_currentSceneIndex}");
            switch (_currentSceneIndex)
            {
                case 0:
                    _audioManager.SetMainMenuMusic();
                    break;
                case > 0:
                    _audioManager.SetGamePlayMusic();
                    break;
            }
        }
    }
}