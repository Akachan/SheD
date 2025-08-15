using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int IsIdle = Animator.StringToHash("isMoving");
    private static readonly int OnEat = Animator.StringToHash("onEat");
    private static readonly int IsHiding = Animator.StringToHash("isHiding");
    private static readonly int SetCamouflageBlend = Animator.StringToHash("SetCamouflageBlend");
    private static readonly int OnCapture = Animator.StringToHash("onCapture");
    private Animator _animatorController;
    private InputManager _input;
    private Player _player;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _input = GetComponentInParent<InputManager>();
        _player = GetComponent<Player>();
    }
    
    public void SetMovingState(bool state)
    {
        _animatorController.SetBool(IsIdle, state);
    }
    public void SetOnEat()
    {
        _animatorController.SetTrigger(OnEat);
    }

    private void Update()
    {
        SetMovingState(_input.MovementValue != Vector2.zero);
        SetCamouflageState();
    }

    private void SetCamouflageState()
    {
        _animatorController.SetBool(IsHiding, _player.IsCamuflaged);
    }

    public void SetHidingBlend(float value)
    {
        _animatorController.SetFloat(SetCamouflageBlend, value);
    }

    public void SetOnCapture()
    {
        _animatorController.SetTrigger(OnCapture);
    }
    
}
