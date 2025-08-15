
using System;
using UnityEngine;

namespace Core
{
    public class SpriteSorter : MonoBehaviour
    {
        [SerializeField] private bool isStatic;
        private SpriteRenderer _sprite;

        void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _sprite.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }

        void LateUpdate()
        {
           if(isStatic) return;
           _sprite.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}

