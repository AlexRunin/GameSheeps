using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    //[SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float jumpForce;
    private Rigidbody rb;
    [SerializeField] private GameObject heartEffect;

    private SheepProperty sheepProperty;

    private void Awake()
    {
        //Debug.Log("Создалась овца с именем: " + sheepProperty.SheepName);
        //sheepProperty.SheepSpeed = 40f;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(direction * sheepProperty.SheepSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) // other -обект с которым столкнулись
    {
        // Компонент наш класс или скрипт
        SenoMovement senoMovement = other.GetComponent<SenoMovement>();
        
        if (senoMovement != null)                                          //(other.gameObject.tag == "Seno")
        {
            soundManager.PlaySheepHitClip();
            rb.isKinematic = false;
            GetComponent<BoxCollider>().enabled = false;
            rb.AddForce(Vector3.up * jumpForce); // прыгаем
            Destroy(gameObject, 1f); //уничтажаем сено Sheep
            Destroy(other.gameObject); //уничтажаем сено 

            GameObject effect = Instantiate(heartEffect, transform.position + new Vector3(0f, 5f, 0f), heartEffect.transform.rotation); // Spawn
            Destroy(effect, 1f);
        }
    }

    public void SetPropertyToSheep(SheepProperty sheepProperty)
    {
        this.sheepProperty = sheepProperty;

        transform.localScale = new Vector3(sheepProperty.SheepSize, sheepProperty.SheepSize, sheepProperty.SheepSize);
    }

}
