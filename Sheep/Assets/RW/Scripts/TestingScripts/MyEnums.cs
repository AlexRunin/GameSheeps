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
    //����������_������� enum ��� : ���
    //{
    //    ���1 = ��������1,
    //    ���2 = ��������2,
    //}

    StudentAge studentAge;
    void Start()
    {
        studentAge = StudentAge.AlexandrR; // ������������������
        int a = (int)studentAge; // �������� �������� ���������
        print(studentAge);
        print(a);
        if (studentAge == StudentAge.Veronika) // �������� ���������
        { 
        
        }
    }
}
