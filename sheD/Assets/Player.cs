using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private InputManager input;
   [SerializeField] private float moveSpeed = 5f;
  

   private void Awake()
   {
      input = FindFirstObjectByType<InputManager>();
   }

   private void FixedUpdate()
   {
      MovePlayer();
   }

   private void MovePlayer()
   {
      Vector3 movement = new Vector3(input.MovementValue.x, input.MovementValue.y, 0) * moveSpeed;
      transform.Translate(movement * Time.fixedDeltaTime, Space.World);
   }
}
