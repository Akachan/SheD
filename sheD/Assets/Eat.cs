using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Eat : MonoBehaviour
{
    
    
    
    [SerializeField] private TextMeshProUGUI foodValueText;
    private int _totalFood = 0;
    private Player _player;
    private float _currentTime = 0;
    private GameObject _camouflageObject;
    private float _foodConsumptionRate;
    private InputManager _input;
    
    
    


    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _input = FindFirstObjectByType<InputManager>();
        
    }

    private void Start()
    {
        _foodConsumptionRate = LevelManager.Instance.FoodConsumptionRate;
    }

    private void Update()
    {
        UpdateFood();
        UpdateText();
        Camouflage();
        
    }

    private void UpdateFood()
    {
        LevelManager.Instance.CurrentFoodCount = _totalFood;
    }

    private void Camouflage()
    {
        if (_player.IsCamuflaged)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _foodConsumptionRate)
            {
                RemoveFood();
                _currentTime = 0;
            }
        }
    }

    private void RemoveFood()
    {
        _totalFood = Mathf.Max(0, _totalFood - 1);
        

        if (_totalFood <= 0)
        {
            _input.OnEatEvent -= PrepareCamouflage;
            _player.IsCamuflaged = false;
            _camouflageObject.SetActive(false);
            _camouflageObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("comida");
            other.gameObject.SetActive(false);
            AddFood(LevelManager.Instance.FoodValue);
        }

        if (other.gameObject.CompareTag("Camuflaje"))
        {
            _camouflageObject = other.gameObject;
            _input.OnEatEvent += PrepareCamouflage;

            //AddFood(LevelManager.Instance.CamouflageFoodValue);
        }
    }

    private void PrepareCamouflage()
    {
        
            print("camuflaje On");
            _player.IsCamuflaged = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Camuflaje"))
        {
            _input.OnEatEvent -= PrepareCamouflage;
            if (_player.IsCamuflaged)
            {
                RemoveCamouflage(other);
            }
            
        }
        
        
    }

    private void RemoveCamouflage(Collider2D other)
    {
        print("camuflaje Off");
        _player.IsCamuflaged = false;
        other.gameObject.SetActive(false);
        _camouflageObject = null;
    }


    private void AddFood(int value)
    {
        _totalFood+=  value;;
        
    }

    private void UpdateText()
    {
        foodValueText.text = _totalFood.ToString();
    }
    
    
}
