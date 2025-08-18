using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
   public class LeeMover : MonoBehaviour
   {
      [Header("Enemy Settings")]
      [SerializeField] private float speed = 5f;
      [SerializeField] private GameObject[] path;
      
      private int _indexPath = 0;
      private GameObject _currentPath;
      private List<Transform> _waypoints = null;
      private SpriteRenderer _leeSprite;
      private bool _isStopped = false;

      private void Awake()
      {
         _leeSprite = GetComponentInChildren<SpriteRenderer>();
      

      }

      private void Start()
      {
         //throw new NotImplementedException();
      }

      private void Update()
      {
         if (_isStopped) return;
         if (_waypoints == null)
         {
            GetRandomPath();
                     
         }

         if (_waypoints == null) return;
         LeeMove();
         SetLeeViewDirection();

         if (transform.position != _waypoints[_indexPath].position) return;
         _indexPath++;
               
         if (_indexPath == _waypoints.Count-1)
         {
            EndPath();
         }
      }

      public void StopLee(bool state)
      {
         _isStopped = state;
      }
      private void EndPath()
      {
         _indexPath = 0;
         _waypoints = null;
      }

      private void LeeMove()
      {
         transform.position = Vector3.MoveTowards(transform.position, _waypoints[_indexPath].position,
            speed * Time.deltaTime);
      }

      private void SetLeeViewDirection()
      {
         var direction = (_waypoints[_indexPath].position -transform.position ).normalized;
         _leeSprite.flipX = direction.x > 0;
      }

      private void GetRandomPath()
      {
         Random random = new Random();
         _currentPath = path[random.Next(0, path.Length)];

         _waypoints = new List<Transform>();

         for (int i = 0; i < _currentPath.transform.childCount; i++)
         {
            _waypoints.Add(_currentPath.transform.GetChild(i));
         }
         _waypoints.Add(_currentPath.transform.GetChild(0));
      }


   }
}
