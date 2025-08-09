using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 _movementValue;
    public Vector2 MovementValue => _movementValue; 
    
    public void OnMove(InputValue value)
    {
        _movementValue = value.Get<Vector2>();
        print(_movementValue);
    }
}
