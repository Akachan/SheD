using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{

   
    [SerializeField] private int foodValueToWin = 20;
    
    [Header("Player Settings")]
    [SerializeField] private float playerSpeed = 5f;

    [Header("Enemy Settings")] 
    [SerializeField]private float enemySpeed = 1f;
    [SerializeField] private float enemySpawnDelay = 10f;
    [SerializeField] private float enemyDetectionRadius = 5f;

    [Header("Food Settings")]
    [SerializeField] private List<FoodContainer> foodContainers = new List<FoodContainer>();

    
    
    private int _currentFoodCount;
    
    public int FoodValueToWin => foodValueToWin;
    public float PlayerSpeed => playerSpeed;
    public float EnemySpeed => enemySpeed;
    public float EnemySpawnDelay => enemySpawnDelay;


    public FoodInventory FoodInventory { get; private set; }


    public int CurrentFoodCount 
    {
        get => _currentFoodCount; 
        set => _currentFoodCount = value; 
    }

   
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
        
        FoodInventory = new FoodInventory(foodContainers);
        
    }




    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
       // Gizmos.DrawWireSphere(enemyTransform.position, enemyDetectionRadius);
    }

    private void OnValidate()
    {
        //enemyDetectionCollider.radius = enemyDetectionRadius * 1/enemyTransform.localScale.x;
        
    }


    public IEnumerator EndGame(EndGameType endType)
    {
        yield return new WaitForSeconds(2);
        switch (endType)
        {
            case EndGameType.Win:
                UiManager.Instance.EnableWinPanel();
                break;
            case EndGameType.Lose:
                UiManager.Instance.EnableGameOverPanel();
                break;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

public enum EndGameType
{
    Lose,
    Win,
    None
}
