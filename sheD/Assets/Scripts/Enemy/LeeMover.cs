using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
   public class LeeMover : MonoBehaviour
   {
      [SerializeField] private GameObject lee;
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
         if (!lee.activeSelf) return;
         if (_isStopped) return;
         if (_waypoints == null)
         {
            GetRandomPath();
                     
         }

         if (_waypoints == null) return;
         LeeMove();
         SetLeeViewDirection();

         if (lee.transform.position != _waypoints[_indexPath].position) return;
         _indexPath++;
               
         if (_indexPath == _waypoints.Count-1)
         {
            EndPath();
         }
      }

      private void EndPath()
      {
         _indexPath = 0;
         _waypoints = null;
      }

      private void LeeMove()
      {
         lee.transform.position = Vector3.MoveTowards(lee.transform.position, _waypoints[_indexPath].position,
            LevelManager.Instance.EnemySpeed * Time.deltaTime);
      }

      private void SetLeeViewDirection()
      {
         var direction = (_waypoints[_indexPath].position -lee.transform.position ).normalized;
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

      public void StopLee()
      {
         _isStopped = true;
      }
   }
}
