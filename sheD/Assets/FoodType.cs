using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodType : MonoBehaviour
{

    [SerializeField] private FoodTypeName foodType;

    public FoodTypeName GetFoodType()
    {
        return foodType;
    }

}

public enum FoodTypeName
{
    Chair,
    Box
}