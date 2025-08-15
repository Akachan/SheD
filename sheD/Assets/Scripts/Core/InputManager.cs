using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private Vector2 _movementValue;
        public Vector2 MovementValue => _movementValue;
        private bool _eatValue;
        public bool EatValue => _eatValue;
        public event Action OnEatEvent;
        public event Action OnPauseEvent;

        private bool _isActive = true;

        private void Awake()
        {
            _playerInput = FindFirstObjectByType<PlayerInput>();
        }

        public void OnMove(InputValue value)
        {
            _movementValue = !_isActive ? new Vector2(0, 0) : value.Get<Vector2>();
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
            _movementValue = Vector2.zero;
        }

        public void OnEscape(InputValue value)
        {
            if (value.isPressed)
            {
                OnPauseEvent?.Invoke();
            }
        }


        public void SwitchToUIMap()
        {
            
            _playerInput.SwitchCurrentActionMap("UI");
        }

        public void SwitchToPlayerMap()
        {
            
            _playerInput.SwitchCurrentActionMap("Player");
        }
    }
}
