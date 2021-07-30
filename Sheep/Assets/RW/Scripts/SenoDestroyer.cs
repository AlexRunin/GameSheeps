using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // любой объект который сопрекаснулся с тригером
    {
        other.gameObject.SetActive(false);//Destroy(other.gameObject);
    }
}
