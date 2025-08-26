using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Eat : MonoBehaviour
{
     [SerializeField]private Player.Player player;

 


    //Entra en contacto con algún objeto que es comida, sin importar el tipo.
    //Toma su Ifood donde cada tipo de comida realizará las acciones correspondientes
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        IFood food = other.gameObject.GetComponent<IFood>();
        if (food != null)
        {
            print("enterCollider");
            food.Eat();
        }
        
        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        print("exit?");
        IFood food = other.gameObject.GetComponent<IFood>();
        if (food != null)
        {
            print("exitCollider");
            food.Vomit();
        }
       
    }
    
    
    
    
    
    /*
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
  

    

    

    private void EatCommonFood(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("comida");
            other.gameObject.SetActive(false);
            AddFood(LevelManager.Instance.FoodValue);
           
            FindFirstObjectByType<AnimationController>().SetOnEat();

        }
    }
    
      */

  
  
    

    
    
    
    
    
    
}
