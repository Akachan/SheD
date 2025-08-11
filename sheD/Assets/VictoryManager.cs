using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
   [SerializeField] private GameObject door;
   private BoxCollider2D _collider;
   private SpriteRevealController _sprite;


   private void Awake()
   {
      _collider =door.GetComponent<BoxCollider2D>();
      _sprite = door.GetComponent<SpriteRevealController>();
   }

   private void Start()
   {
      SetColliderState(false);
      SetDoorState(0f);
   }

   private void SetDoorState(float f)
   {
      _sprite.SetFillAmount(f);
   }

   private void SetColliderState(bool state)
   {
      _collider.enabled = state;
   }

   private void Update()
   {
      var fillValue = LevelManager.Instance.CurrentFoodCount / (float)LevelManager.Instance.FoodValueToWin;
     
      SetDoorState(fillValue);
      
      if (fillValue >= 1)
      {
         SetColliderState(true);
         
      }
      else
      {
         SetColliderState(false);
      }
   }


}
