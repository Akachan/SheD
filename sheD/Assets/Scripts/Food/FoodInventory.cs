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
        private CommonFoodTypeName _camouflageReSourceFood;


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
                    _camouflageReSourceFood = container.FoodType;
                }
            }
        }
        
        public void AddFood(CommonFoodTypeName food)
        {
            _inventory[food].AddFood();
        }

        public int GetFoodCount(CommonFoodTypeName food)
        {
            return _inventory[food].CurrentCount;
        }
        
        
        //CamouflageResource Only
        public bool ConsumeCamouflageFood(float time)
        {
            if (time >= _inventory[_camouflageReSourceFood].TimeToRemoveResource)
            {
                _inventory[_camouflageReSourceFood].RemoveFood();
                return true;
            }
            return false;
        }

        public bool IsEmptyCamouflageFood()
        {
            return _inventory[_camouflageReSourceFood].CurrentCount == 0;
        }
    }
    
   
    

}

 