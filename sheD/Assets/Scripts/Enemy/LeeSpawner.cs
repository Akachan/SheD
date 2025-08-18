using Core;
using UnityEngine;

namespace Enemy
{
    public class LeeSpawner : MonoBehaviour
    {
        [Header("Enemy Spawn Settings")]
        [SerializeField] private float spawnDelay = 3f;
        
        [Header("References")]
        [SerializeField] private SpriteRenderer leeSprite;
    
        private float _currentTime = 0;
        private CircleCollider2D _collider;
        private LeeMover _leeMover;
        private bool _isSpawned = false;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _leeMover = GetComponent<LeeMover>();
            
        }

        void Start()
        {
            leeSprite.enabled = false;
            _leeMover.StopLee(true);
            
        }
        
        void Update()
        {
            if (_isSpawned) return;
            
            _currentTime += Time.deltaTime;
            
            if (!(_currentTime >= spawnDelay)) return;
            
            leeSprite.enabled = true;
            _isSpawned = true;
            _leeMover.StopLee(false);
        }

        private void SetDetectionRadius(float value)
        {
            _collider.radius = value;
        }
    }
}
