
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Food
{
    //No necesita inicializarse ya que se se realiza en el inspector del LVLMNGR
    [Serializable]
    public class FoodContainer
    {
        [SerializeField] private CommonFoodTypeName foodType;
        [SerializeField] private int initialCount;
        [SerializeField] private int maxCount;
        [SerializeField] private int minFoodValueAdded;
        [SerializeField] private int maxFoodValueAdded;
        [SerializeField] private bool isCamouflageResource;
        [SerializeField] private float consumptionRate;
        
        private int _currentCount;
        
        public CommonFoodTypeName FoodType => foodType;
        public bool IsCamouflageResource => isCamouflageResource;
        public int CurrentCount => _currentCount;

     
        public float TimeToRemoveResource => 1 / consumptionRate;

        public void InitializeContainer()
        {
            _currentCount = Mathf.Min(initialCount, maxCount);;
        }

        public void AddFood()
        {
            var foodToAdd= Random.Range(minFoodValueAdded, maxFoodValueAdded);
            _currentCount = Mathf.Clamp(_currentCount + foodToAdd, 0, maxCount);
        }
        
        public void RemoveFood()
        {
            _currentCount = Mathf.Clamp(_currentCount -1, 0, maxCount);
           
        }
        public float FoodContainerFillRatio()
        {
            if (maxCount == 0)
            {
                Debug.LogWarning("No se ingresó el valor de MaxCount");
                return 0f;
            }

            return _currentCount / (float)maxCount;

        }
    }

}