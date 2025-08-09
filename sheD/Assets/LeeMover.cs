using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LeeMover : MonoBehaviour
{
   [SerializeField] private GameObject lee;
   [SerializeField] private GameObject[] path;

   private int _indexPath = 1;
   private Transform[] _currentPath = null;
   private SpriteRenderer _leeSprite;

   private void Awake()
   {
      _leeSprite = GetComponentInChildren<SpriteRenderer>();
      

   }

   private void Update()
   {
      if (!lee.activeSelf) return;
      if (_currentPath == null)
      {
         GetRandomPath();
                     
      }

      if (_currentPath == null) return;
      LeeMove();
      SetLeeViewDirection();

      if (lee.transform.position != _currentPath[_indexPath].position) return;
      _indexPath++;
               
      if (_indexPath == _currentPath.Length-1)
      {
         EndPath();
      }
   }

   private void EndPath()
   {
      _indexPath = 1;
      _currentPath = null;
   }

   private void LeeMove()
   {
      lee.transform.position = Vector3.MoveTowards(lee.transform.position, _currentPath[_indexPath].position,
         LevelManager.Instance.EnemySpeed * Time.deltaTime);
   }

   private void SetLeeViewDirection()
   {
      var direction = (_currentPath[_indexPath].position - _currentPath[_indexPath - 1].position).normalized;
      _leeSprite.flipX = direction.x > 0;
   }

   private void GetRandomPath()
   {
      Random random = new Random();
      _currentPath = path[random.Next(0, path.Length)].GetComponentsInChildren<Transform>();
      
   }
}
