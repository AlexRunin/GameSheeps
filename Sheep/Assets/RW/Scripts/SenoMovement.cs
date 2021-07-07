using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float jumpForce;
    private Rigidbody rb;
    [SerializeField] private GameObject heartEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) // other -����� � ������� �����������
    {
        if (other.gameObject.tag == "Seno")
        {
            rb.isKinematic = false;
            GetComponent<BoxCollider>().enabled = false;
            rb.AddForce(Vector3.up * jumpForce); // �������
            Destroy(gameObject, 1f); //���������� ���� Sheep
            Destroy(other.gameObject); //���������� ���� 

            GameObject effect = Instantiate(heartEffect, transform.position + new Vector3(0f, 5f, 0f), heartEffect.transform.rotation); // Spawn
            Destroy(effect, 1f);
        }
    }
}
