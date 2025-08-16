using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
   [Header("Victory Condition")]
   [SerializeField] private CommonFoodTypeName foodType;
   [SerializeField] private int foodCountToWin;
   
   [Header("No taocar")]
   [SerializeField] private GameObject door;

   [SerializeField] private GameObject closeDoor;
   [SerializeField] private GameObject openDoor;
   
   private BoxCollider2D _collider;
   private SpriteRevealController _sprite;

   private bool _isOpen;


   private void Awake()
   {
      _collider = GetComponent<BoxCollider2D>();
      _sprite = door.GetComponent<SpriteRevealController>();
   }

   private void Start()
   {
      SetDoorState(LevelManager.Instance.FoodInventory.GetFoodRatio(foodType));
   }

   
   private void Update()
   {
      SetDoorShader();

      _isOpen = LevelManager.Instance.FoodInventory.GetFoodCount(foodType) >= foodCountToWin;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Player")) return;
      
      Debug.Log("Player tocó puerta");
      if (_isOpen)
      {
         StartCoroutine(LevelManager.Instance.EndGame(EndGameType.Win));
      }
      else
      {
         Debug.Log("No tienes suficiente material");
         UiManager.Instance.SetMessage("No tienes suficiente material");
         //poner algun mensaje de que le falta cierto material
      }
   }

   private void SetDoorShader()
   {
      var foodCount = LevelManager.Instance.FoodInventory.GetFoodCount(foodType);
      var fillValue = Mathf.Clamp(foodCount / (float) foodCountToWin,0f,1f);
      SetDoorState(fillValue);
      if (foodCount >= foodCountToWin)
      {
         closeDoor.SetActive(false);
         openDoor.SetActive(true);
      }
   }

   private void SetDoorState(float f)
   {
      _sprite.SetFillAmount(f);
   }

}
