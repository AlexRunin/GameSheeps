using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // ����� ������ ������� ������������� � ��������
    {
        other.gameObject.SetActive(false);//Destroy(other.gameObject);
    }
}
