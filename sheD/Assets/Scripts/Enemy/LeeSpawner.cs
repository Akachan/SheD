using UnityEngine;

namespace Enemy
{
    public class LeeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject lee;
    
        private float _currentTime = 0;
    
        private CircleCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
        }

        void Start()
        {
            lee.SetActive(false);
        }

   
        void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= LevelManager.Instance.EnemySpawnDelay)
            {
                lee.SetActive(true);
            }
        }

        private void SetDetectionRadius(float value)
        {
            _collider.radius = value;
        }
    }
}
