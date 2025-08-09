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
    


    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        
    }

    private void Start()
    {
        _foodConsumptionRate = LevelManager.Instance.FoodConsumptionRate;
    }

    private void Update()
    {
        UpdateText();
        Camouflage();
        
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
        _totalFood--;

        if (_totalFood == 0)
        {
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

            print("camuflaje On");
            _camouflageObject = other.gameObject;
            _player.IsCamuflaged = true;
            AddFood(LevelManager.Instance.CamouflageFoodValue);
            

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Camuflaje"))
        {
            print("camuflaje Off");
            _player.IsCamuflaged = false;
            other.gameObject.SetActive(false);
            _camouflageObject = null;
        }
        
        
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
