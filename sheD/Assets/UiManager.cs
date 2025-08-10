using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
   [SerializeField] private GameObject gameOverPanel;
   
   public static UiManager Instance { get; private set; }

   private void Awake()
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


   public void OnRestartButtonClick()
   {
      LevelManager.Instance.RestartScene();
   }
}
