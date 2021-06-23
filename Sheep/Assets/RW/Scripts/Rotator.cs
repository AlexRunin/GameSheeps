using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Rotate Property")]
    [SerializeField] Vector3 rotateDiraction;
    [Range(-100f, 100f)] [SerializeField] float rotateSpeed;
    
    
    void Start()
    {
        //rotateDiraction = new Vector3(0f, rotatespeed, 0f);
    }

    
    void Update()
    {
        transform.Rotate(rotateDiraction * rotateSpeed * Time.deltaTime);
    }
}
