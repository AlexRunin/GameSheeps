using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepProperty", menuName = "ScriptableObjects/NewSheepProperty")] //������� ���� ��� Unity
public class SheepProperty : ScriptableObject
{
    [SerializeField] private string sheepName;
    [SerializeField] private float sheepSpeed;
    // �������� ������ ���� Vectar3

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
                Debug.LogWarning("�������� �� ���� ������! �� ��������� ����� 5");
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
                Debug.LogWarning("�������� ���� ��������� ������ 20-��!");
                sheepSpeed = 20f;
            }
            else
            {
                sheepSpeed = value;
            }
            
        }
    }
    // public string SheepName { get; set; } // �������� ����� ������
    //public float SheepSpeed => sheepSpeed; // ���������� - public float SheepSpeed { get {retuen sheepSpeed;} }

    //private void OnDisable()
    //{
    //    sheepSpeed = 50;
    //}



}
