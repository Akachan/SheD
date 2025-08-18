using Core;
using Food;
using UnityEngine;

namespace Player
{
   public class Player : MonoBehaviour
   {
      [Header("Player Settings")]
      [SerializeField]private float moveSpeed = 5f;
   
      [Header("References")]
      [SerializeField] GameObject foodArea;
      [SerializeField] Transform leftVsfPosition;
      [SerializeField] Transform rightVfxPosition;
      [SerializeField] private AnimationController animation;
   
      private InputManager _input;
      private SpriteRenderer _spriteRenderer;
      private bool _isCamouflaged = false;
      private bool _isIdle;
      private float _currentTime = 0f;

   
      //cosas de vsf
      private VsfPosition _currentVfxPosition;
      public VsfPosition CurrentVfxPosition => _currentVfxPosition;

      public bool IsCamouflaged
      {
         get => _isCamouflaged;
         private set => _isCamouflaged = value;
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
      
      }

      private void Update()
      {
         MovePlayer();
         ConsumeCamouflageResource();
      }

      private void ConsumeCamouflageResource()
      {
         if (IsCamouflaged)
         {
            _currentTime += Time.deltaTime;
         
            if (LevelManager.Instance.FoodInventory.ConsumeCamouflageFood(_currentTime))
            {
               _currentTime = 0f;
            }
            if (LevelManager.Instance.FoodInventory.IsEmptyCamouflageFood())
            {
               RemoveCamouflage();
            }
         }
         else
         {
            _currentTime = 0;
         }
      }


      private void MovePlayer()
      {
         Vector3 movement = new Vector3(_input.MovementValue.x, _input.MovementValue.y, 0) * moveSpeed;
         GetComponent<Rigidbody2D>().velocity = movement;
      
         FlipPlayerToViewDirection();

      
         //En caso de que el player esté camuflado y se mueva, perderá el camuflaje
         if (_input.MovementValue != Vector2.zero && IsCamouflaged)
         {
            print("se movió");
            RemoveCamouflage();
         }
      }

      //todo: Arregla toda esta aberración
      private void FlipPlayerToViewDirection()
      {
         if (_input.MovementValue.x == 0) return;
         
         //flipeo sprite
         _spriteRenderer.flipX = _input.MovementValue.x < 0;
         
         //flipeo el área de comida
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
   
      //CAMUFLAJE***************************************
      public void SetCamouflage (CamouflageFoodTypeName camouflageFoodType)
      {
         IsCamouflaged = true;
         animation.SetOnEat();
         animation.SetHidingBlend((float)camouflageFoodType);
      }

      private void RemoveCamouflage()
      {
         print("camuflaje off");
         IsCamouflaged = false;
      }

   }
}
