using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float playerSpeed = 5f;

    [Header("Enemy Settings")] 
    [SerializeField]private float enemySpeed = 1f;
    [SerializeField] private float enemySpawnDelay = 10f;
    [SerializeField] private float enemyDetectionRadius = 5f;
    
    [Header("Food Settings")]
    [SerializeField] private int minFoodValue = 1;
    [SerializeField] private int maxFoodValue = 10;
    
    [SerializeField] private int camouflageFoodValue = 1;
    [SerializeField] private float foodConsumptionRate = 1f;
    
    
    
    public float PlayerSpeed => playerSpeed;
    public float EnemySpeed => enemySpeed;
    public float EnemySpawnDelay => enemySpawnDelay;
    public float EnemyDectionRadious => enemyDetectionRadius;
    public int FoodValue => Random.Range(minFoodValue, maxFoodValue);
    public int CamouflageFoodValue => camouflageFoodValue;
    public float FoodConsumptionRate => 1/foodConsumptionRate;

   
    [Header("No tocar")]
    [SerializeField] private Transform enemyTransform;

    [SerializeField] private CircleCollider2D enemyDetectionCollider;
    
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else Instance = this;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyTransform.position, enemyDetectionRadius);
    }

    private void OnValidate()
    {
        enemyDetectionCollider.radius = enemyDetectionRadius * 1/enemyTransform.localScale.x;
    }
}
