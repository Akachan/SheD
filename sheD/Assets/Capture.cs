using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capture : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
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
        _player.GetComponent<SpriteRenderer>().flipY = true;
        StartCoroutine((EndGame()));
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
