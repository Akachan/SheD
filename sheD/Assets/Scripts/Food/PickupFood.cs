using Core;
using UnityEngine;

namespace Food
{
    public class PickupFood : MonoBehaviour, IFood
    {
        [SerializeField] private CommonFoodTypeName foodType;
        
        public void Eat()
        {
        
            gameObject.SetActive(false);
            LevelManager.
           
            FindFirstObjectByType<AnimationController>().SetOnEat();
            
            LevelManager.Instance.FoodInventory.AddFood(foodType);
            
        }

    
    
        //Not necesary
        public void Vomit()
        {
      
        }
    }
}
