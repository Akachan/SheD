using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{ 
    [SerializeField] private GameObject howToPlayPanel;



    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnHowToPlayButtonClick()
    {
        howToPlayPanel.SetActive(true);
    }

    public void OnHowToPlayCloseButtonClick()
    {
        howToPlayPanel.SetActive(false);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
