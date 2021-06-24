using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSheeps : MonoBehaviour
{
    [Header("Rotate Sheeps")]
    [SerializeField] Vector3 rotateDiraction;
    [Range(-100f, 100f)] [SerializeField] float rotateSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(rotateDiraction * rotateSpeed * Time.deltaTime);
    }
}
