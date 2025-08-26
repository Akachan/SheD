using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EnemySfx : MonoBehaviour
{
    [SerializeField] private EventReference footstepSfx;
    private Player.Player _player;
    public void StepSfx()
    {
        RuntimeManager.PlayOneShotAttached(footstepSfx, gameObject);
        //print("STEP");
    }

    private void Awake()
    {
        _player = FindFirstObjectByType<Player.Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
