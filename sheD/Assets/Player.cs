using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
   private InputManager _input;
   //private float moveSpeed = 5f;
   private SpriteRenderer _spriteRenderer;
   [SerializeField] GameObject foodArea;
   [SerializeField] Transform leftVsfPosition;
   [FormerlySerializedAs("rightVsfPosition")] [SerializeField] Transform rightVfxPosition;
   private Eat _eat;
   private bool _isCamouflaged = false;
   private bool _isIdle;

   private VsfPosition _currentVfxPosition;
   public VsfPosition CurrentVfxPosition => _currentVfxPosition;
   public bool IsIdle => _isIdle;
   public bool IsCamuflaged
   {
      get => _isCamouflaged;
      set => _isCamouflaged = value;
   }

   public struct VsfPosition
   {
      public Transform VsfTransform;
      public float VsfScale;
   }

   private void Awake()
   {
      _input = FindFirstObjectByType<InputManager>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _eat = FindFirstObjectByType<Eat>();
   }

   private void Update()
   {
      //Camuflaje();
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
         //flipeo sprite
         _spriteRenderer.flipX = _input.MovementValue.x < 0;
         
         //flipeo el area de comida
         var scale = foodArea.transform.localScale;
         scale.x = _input.MovementValue.x < 0 ? -1 : 1;
         foodArea.transform.localScale = scale;
         
         //flipeo la ubicación del vsf
         if (_spriteRenderer.flipX)
         {
            _currentVfxPosition = new VsfPosition()
            {
               VsfTransform = leftVsfPosition,
               VsfScale = -1
            };
         }
         else
         {
            _currentVfxPosition = new VsfPosition()
            {
               VsfTransform = rightVfxPosition,
               VsfScale = 1
            };
         }
         
         
      }
   }
   
   
   //Outdated
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
