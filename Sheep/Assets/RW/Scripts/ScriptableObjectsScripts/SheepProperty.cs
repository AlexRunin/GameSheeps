using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepProperty", menuName = "ScriptableObjects/NewSheepProperty")] //������� ���� ��� Unity
public class SheepProperty : ScriptableObject
{
    [SerializeField] public string sheepName;
    [SerializeField] public float sheepSpeed;
    [SerializeField] public float sheepSize;
    // �������� ������ ���� Vectar3
    public float SheepSize
    {
        get { if (sheepSize == 0) { return sheepSize = 2f; } else { return sheepSize; } }
        set { if (value == 0) { sheepSize = 2f; } else { sheepSize = 2f; } }
        
    }
    public string SheepName
    {
        get
        {
            if (sheepName == "")
            {
                Debug.LogWarning("No Name Sheep");
                //return "None Name";
                return sheepName = "Name1";
            }
            else
            {
                return sheepName;
            }
        }
        set
        {
            if(sheepName == "") { sheepName = "name1"; }
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
