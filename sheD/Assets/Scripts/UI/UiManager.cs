using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private GameObject winPanel;
   
   [Header("Pause Settings")]
   [SerializeField] private GameObject pausePanel;
   [SerializeField] private GameObject resumeButton;

   [SerializeField] private MessageSetter messagePanel;
   
   public static UiManager Instance { get; private set; }
   private  EventSystem _eventSystem;
   public event Action OnRemoveAction;
   
   private void Awake()
   {
      SetInstance();
      _eventSystem = FindObjectOfType<EventSystem>();
   }

   private void SetInstance()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(this);
      }
      else Instance = this;
   }

   public void EnableGameOverPanel()
   {
      gameOverPanel.SetActive(true);
   }
   public void EnableWinPanel()
   {
      winPanel.SetActive(true);
   }
   public void EnablePausePanel()
   {
      pausePanel.SetActive(true);  
      _eventSystem.SetSelectedGameObject(resumeButton);
   }
   public void DisablePausePanel()
   {
      pausePanel.SetActive(false); 
   }

   public void SetMessage(string message)
   {
      messagePanel.SetMessage(message);
   }

   //BUTTONS
   public void OnRestartButtonClick()
   {
      OnRemoveAction?.Invoke();
      LevelManager.Instance.RestartScene();
   }

   public void OnBackToMenuButtonClick()
   {
      OnRemoveAction?.Invoke();
      SceneManager.LoadScene("MainMenu");
   }




   public void OnToDesktopButton()
   {
      
      Application.Quit();
   }
}
