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
   private Eat _eat;
  

   private void Awake()
   {
      _input = FindFirstObjectByType<InputManager>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _eat = FindFirstObjectByType<Eat>();
   }

   private void FixedUpdate()
   {
      Camuflaje();
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

   private void Camuflaje()
   {
      if (_eat.IsCamuflaged)
      {
         var color = _spriteRenderer.color;
         color.a = 0.5f;
         _spriteRenderer.color = color;
      }
      else
      {
         var color = _spriteRenderer.color;
         color.a = 1f;
         _spriteRenderer.color = color;
      }
   }
}
