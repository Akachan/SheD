using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private InputManager _input;
   //private float moveSpeed = 5f;
   private SpriteRenderer _spriteRenderer;
   [SerializeField] GameObject foodArea;
   private Eat _eat;
   private bool _isCamouflaged = false;
   private bool _isIdle;
   public bool IsIdle => _isIdle;
   public bool IsCamuflaged
   {
      get => _isCamouflaged;
      set => _isCamouflaged = value;
   }


   private void Awake()
   {
      _input = FindFirstObjectByType<InputManager>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _eat = FindFirstObjectByType<Eat>();
   }

   private void Update()
   {
      Camuflaje();
      MovePlayer();
   }
   
   private void Camuflaje()
   {
      if (IsCamuflaged)
      {
         SetCamouflage();
      }
      else
      {
         RemoveCamouflage();
      }
   }

   private void MovePlayer()
   {
      Vector3 movement = new Vector3(_input.MovementValue.x, _input.MovementValue.y, 0) * LevelManager.Instance.PlayerSpeed;
      transform.Translate(movement * Time.fixedDeltaTime, Space.World);
      
      FlipPlayerToViewDirection();
      
   }

   private void FlipPlayerToViewDirection()
   {
      if (_input.MovementValue.x != 0)
      {
         _spriteRenderer.flipX = _input.MovementValue.x < 0;
         var scale = foodArea.transform.localScale;
         scale.x = _input.MovementValue.x < 0 ? -1 : 1;
         foodArea.transform.localScale = scale;
         
      }
   }
   private void RemoveCamouflage()
   {
      var color = _spriteRenderer.color;
      color.a = 1f;
      _spriteRenderer.color = color;
   }

   private void SetCamouflage()
   {
      var color = _spriteRenderer.color;
      color.a = 0.5f;
      _spriteRenderer.color = color;
   }
}
