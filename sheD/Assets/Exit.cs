using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("colisionó");
        StartCoroutine(LevelManager.Instance.EndGame(EndGameType.Win));
    }


}
