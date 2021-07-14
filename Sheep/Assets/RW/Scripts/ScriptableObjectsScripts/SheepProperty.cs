using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepProperty", menuName = "ScriptableObjects/NewSheepProperty")] //Создаем меню для Unity
public class SheepProperty : ScriptableObject
{
    [SerializeField] private string sheepName;
    [SerializeField] private float sheepSpeed;
    // Добавить размер овце Vectar3

    public string SheepName
    {
        get
        {
            if (sheepName == "")
            {
                Debug.LogWarning("No Name Sheep");
                return "None Name";
            }
            else
            {
                return sheepName;
            }
        }
        set
        {
            sheepName = value;
        }
    }
    public float SheepSpeed
    {
        get 
        {
            if (sheepSpeed == 0)
            {
                Debug.LogWarning("Скорость не была задана! По умолчанию будет 5");
                return sheepSpeed = 5f;
            }
            else
            {
                return sheepSpeed;
            }
        }
        private set
        {
            if (value > 20f)
            {
                Debug.LogWarning("Скорость была превышена больше 20-ти!");
                sheepSpeed = 20f;
            }
            else
            {
                sheepSpeed = value;
            }
            
        }
    }
    // public string SheepName { get; set; } // короткая форма запись
    //public float SheepSpeed => sheepSpeed; // эквивалент - public float SheepSpeed { get {retuen sheepSpeed;} }

    //private void OnDisable()
    //{
    //    sheepSpeed = 50;
    //}



}
