using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class SliderUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodType;
    [SerializeField] private Image sliderBar;
    [SerializeField] private TextMeshProUGUI valueText;

    public void Initialize(Food.CommonFoodTypeName foodName)
    {
        foodType.text = foodName.ToString();

        var foodCount = LevelManager.Instance.FoodInventory.GetFoodCount(foodName);
        valueText.text = foodCount.ToString();

        var ratio = LevelManager.Instance.FoodInventory.GetFoodRatio(foodName);
        sliderBar.fillAmount = ratio;
        
        //print($" inicializado {foodName}, con {foodCount} elemento y un ratio de {ratio}");
    }

    public void UpdateSlider (CommonFoodTypeName foodName)
    {

        var foodCount = LevelManager.Instance.FoodInventory.GetFoodCount(foodName);
        valueText.text = foodCount.ToString();

        var ratio = LevelManager.Instance.FoodInventory.GetFoodRatio(foodName);
        sliderBar.fillAmount = ratio;
        
        
        //print($" actualizado {foodName}, con {foodCount} elemento y un ratio de {ratio}");
    }





}
   
