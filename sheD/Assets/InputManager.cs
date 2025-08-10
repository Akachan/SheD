using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 _movementValue;
    public Vector2 MovementValue => _movementValue;
    private bool _eatValue;
    public bool EatValue => _eatValue;
    public event Action OnEatEvent;

    private bool _isActive = true;
    
    public void OnMove(InputValue value)
    {
        if (!_isActive)
        {
            _movementValue = new Vector2(0, 0);
            
        }
        else
        {
            _movementValue = value.Get<Vector2>();
        }
        
        
    }

    public void OnEat(InputValue value)
    {
        _eatValue = value.isPressed;
        if (_eatValue)
        {
            OnEatEvent?.Invoke();
            print("apretaste la E");
        }
    }

    public void SetInputActive(bool value)
    {
        _isActive = value;
    }
}
