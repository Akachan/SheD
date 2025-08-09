using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeMover : MonoBehaviour
{
   [SerializeField] private GameObject lee;
   [SerializeField] private Transform[] path;
   [SerializeField] private float speed = 1f;
   private int _indexPath = 0;


   private void Update()
   {
      if (lee.activeSelf)
      {
         
         lee.transform.position = Vector3.MoveTowards(lee.transform.position, path[_indexPath].position, speed * Time.deltaTime);

         if (lee.transform.position == path[_indexPath].position)
         {
            _indexPath++;
            if (_indexPath >= path.Length)
            {
               lee.SetActive(false);
            }
         }
      }
   }
}
