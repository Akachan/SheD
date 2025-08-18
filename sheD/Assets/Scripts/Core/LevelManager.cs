using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Food Settings")]
        [SerializeField] private List<FoodContainer> foodContainers = new List<FoodContainer>();
        public FoodInventory FoodInventory { get; private set; }
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
}