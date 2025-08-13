using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
namespace Food
{
    public class FoodInventory
    {
        private Dictionary<CommonFoodTypeName, FoodContainer> _inventory = new Dictionary<CommonFoodTypeName, FoodContainer>();
        private CommonFoodTypeName _camouflageResourceFood;
        
        public event Action<CommonFoodTypeName> OnFoodChange;
        
        public FoodInventory(List<FoodContainer> containers)
        {
            CreateInventory(containers);
        }

        private void CreateInventory(List<FoodContainer> containers)
        {
            _inventory = new Dictionary<CommonFoodTypeName, FoodContainer>();
            foreach (var container in containers)
            {
                container.InitializeContainer();
                _inventory.Add(container.FoodType, container);
                
                
                Debug.Log($"Nombre: {container.FoodType} - Contenido: {container.CurrentCount}");
                if (container.IsCamouflageResource)
                {
                    _camouflageResourceFood = container.FoodType;
                }
            }
            
        }
        
        public void AddFood(CommonFoodTypeName food)
        {
            _inventory[food].AddFood();
            
            OnFoodChange?.Invoke(food);
        }

        public int GetFoodCount(CommonFoodTypeName food)
        {
            return _inventory[food].CurrentCount;
        }

        public float GetFoodRatio(CommonFoodTypeName food)
        {
            return _inventory[food].FoodContainerFillRatio;
        }
        
        
        //CamouflageResource Only
        public bool ConsumeCamouflageFood(float time)
        {
            if (time >= _inventory[_camouflageResourceFood].TimeToRemoveResource)
            {
                _inventory[_camouflageResourceFood].RemoveFood();
                
                OnFoodChange?.Invoke(_camouflageResourceFood);
                return true;
            }
            return false;
        }

        public bool IsEmptyCamouflageFood()
        {
            return _inventory[_camouflageResourceFood].CurrentCount == 0;
        }
    }


    
   
    

}

 