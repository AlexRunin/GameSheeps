using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum StudentAge : int
{ 
    AlexandrK = 40,
    AlexandrR = 31,
    Veronika = 14
}

public class MyEnums : MonoBehaviour
{
    //модификтор_доступа enum им€ : тип
    //{
    //    им€1 = значение1,
    //    им€2 = значение2,
    //}

    StudentAge studentAge;
    void Start()
    {
        studentAge = StudentAge.AlexandrR; // Ќазначитьсосто€ние
        int a = (int)studentAge; // получить значение состо€ние
        print(studentAge);
        print(a);
        if (studentAge == StudentAge.Veronika) // —равнить состо€ние
        { 
        
        }
    }
}
