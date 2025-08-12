using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;

public class CamouflageFood : MonoBehaviour, IFood
{
    [SerializeField] private CamouflageFoodTypeName camouflageFoodType;
    private InputManager _input;
    private Player _player;

    private void Awake()
    {
        _input = FindFirstObjectByType<InputManager>();
        _player = FindFirstObjectByType<Player>();
    }

    //Si el player entra en contacto con una comida que otorga camuflaje, agrega la acción "Camouflage" al Botón E
    public void Eat()
    {
        _input.OnEatEvent += Camouflage;
    }

    
    //Si el player sale del contacto con una comida que otorga camuflaje, retira la acción "Camouflage" del Botón E
    public void Vomit()
    {
        _input.OnEatEvent -= Camouflage;
    }


    //Ejecutar el camuflaje implica eliminar este objeto, hacer la animación del player y quitar la posibilidad
    //de volver a ejecutar el camouflaje con la E
    private void Camouflage()
    {
        
        print("camuflaje On");
        _input.OnEatEvent -= Camouflage;
        gameObject.SetActive(false);
        _player.SetCamouflage(camouflageFoodType);
        

    }
    

}
