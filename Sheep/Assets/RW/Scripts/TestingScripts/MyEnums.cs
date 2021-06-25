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
    //модификтор_доступа enum имя : тип
    //{
    //    имя1 = значение1,
    //    имя2 = значение2,
    //}

    StudentAge studentAge;
    void Start()
    {
        studentAge = StudentAge.AlexandrR;
        int a = (int)studentAge;
        print(studentAge);
        print(a);
        
    }
}
