using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{ 
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject creditsPanel;



    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnHowToPlayButtonClick()
    {
        howToPlayPanel.SetActive(true);
    }

    public void OnCreditsButtonClick()
    {
        creditsPanel.SetActive(true);   
    }
    public void OnCreditsCloseButtonClick()
    {
        creditsPanel.SetActive(false);
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
