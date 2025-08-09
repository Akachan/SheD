using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Eat : MonoBehaviour
{
    
    
    
    [SerializeField] private TextMeshProUGUI foodValueText;
    private int _totalFood = 0;
    private bool _isCamouflaged = false;
    private float _currentTime = 0;
    private GameObject _camouflajeObject;
    public bool IsCamuflaged => _isCamouflaged;


    private void Update()
    {
        UpdateText();
        Camouflage();
        
    }

    private void Camouflage()
    {
        if (_isCamouflaged)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= 1)
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
            _isCamouflaged = false;
            _camouflajeObject.SetActive(false);
            _camouflajeObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("comida");
            other.gameObject.SetActive(false);
            AddFood();
        }

        if (other.gameObject.CompareTag("Camuflaje"))
        {

            print("camuflaje On");
            _camouflajeObject = other.gameObject;
            _isCamouflaged = true;
            AddFood();
            

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Camuflaje"))
        {
            print("camuflaje Off");
            _isCamouflaged = false;
            other.gameObject.SetActive(false);
            _camouflajeObject = null;
        }
        
        
    }


    private void AddFood()
    {
        _totalFood++;
        
    }

    private void UpdateText()
    {
        foodValueText.text = _totalFood.ToString();
    }
}
