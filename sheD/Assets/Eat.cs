using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodValueText;
    private int totalFood = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("comida");
            other.gameObject.SetActive(false);
            AddFood();
            UpdateText();
        }
    }


    private void AddFood()
    {
        totalFood++;
        
    }

    private void UpdateText()
    {
        foodValueText.text = totalFood.ToString();
    }
}
