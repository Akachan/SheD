using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private EventReference hide;
    private EventInstance _hideEventInstance;
    private Player _player;
    // Start is called before the first frame update

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    void Start()
    {
        _hideEventInstance = RuntimeManager.CreateInstance(hide);
        
        
        
    }

    public void Hide()
    {
        
        _hideEventInstance.start();
    }

    private void Update()
    {
        int estado = 0;
        if (_player.IsCamuflaged)
        {
            estado = 0;
        }
        else
        {
            estado = 1;
        }
        _hideEventInstance.setParameterByName("estado", estado );
        
        float  comida = Mathf.Min(LevelManager.Instance.CurrentFoodCount / (float)LevelManager.Instance.FoodValueToWin,1f);;
        _hideEventInstance.setParameterByName("comida", comida );
    }
}
