using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private InputManager _input;
   [SerializeField] private float moveSpeed = 5f;
   private SpriteRenderer _spriteRenderer;
   [SerializeField] GameObject foodArea;
  

   private void Awake()
   {
      _input = FindFirstObjectByType<InputManager>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void FixedUpdate()
   {
      MovePlayer();
   }

   private void MovePlayer()
   {
      Vector3 movement = new Vector3(_input.MovementValue.x, _input.MovementValue.y, 0) * moveSpeed;
      transform.Translate(movement * Time.fixedDeltaTime, Space.World);
      
      if (_input.MovementValue.x != 0)
      {
         _spriteRenderer.flipX = _input.MovementValue.x < 0;
         var scale = foodArea.transform.localScale;
         scale.x = _input.MovementValue.x < 0 ? -1 : 1;
         foodArea.transform.localScale = scale;
         
      }
   }
}
