using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Food;
using Unity.VisualScripting;
using UnityEngine;


public class HudManager : MonoBehaviour
{
    [SerializeField] private HudSlider[] sliders;

    private Dictionary<CommonFoodTypeName, SliderUpdater> _sliders;
      


    private void Start()
    {
        CreateSliderDictionary();

        foreach (var s in _sliders)
        {
            s.Value.Initialize(s.Key);
        }

        LevelManager.Instance.FoodInventory.OnFoodChange += UpdateFoodSliders;
    }

    private void CreateSliderDictionary()
    {
        _sliders = new Dictionary<CommonFoodTypeName, SliderUpdater>();
        foreach (var slider in sliders)
        {
            _sliders.Add(slider.FoodType, slider.SliderUpdater);
        }
    }

    private void UpdateFoodSliders(CommonFoodTypeName foodType)
    {
        _sliders[foodType].UpdateSlider(foodType);
    }
}





[Serializable]


public class HudSlider
{
    [SerializeField] private CommonFoodTypeName foodType;
    [SerializeField] private SliderUpdater sliderUpdater;
    
    public CommonFoodTypeName FoodType => foodType;
    public SliderUpdater SliderUpdater => sliderUpdater;
    
}