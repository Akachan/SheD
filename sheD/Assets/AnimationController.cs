using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int IsIdle = Animator.StringToHash("isMoving");
    private Animator _animatorController;
    private InputManager _input;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _input = GetComponentInParent<InputManager>();
    }
    
    public void SetMovingState(bool state)
    {
        _animatorController.SetBool(IsIdle, state);
    }

    private void Update()
    {
        SetMovingState(_input.MovementValue != Vector2.zero);
    }
}
