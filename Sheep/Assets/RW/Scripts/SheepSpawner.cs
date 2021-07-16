using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sheepPrefab;
    [SerializeField] private Vector3 spawnPointPosition;
    [SerializeField] private Vector2 boundary; //граница
    [SerializeField] private float spawnRate; //чистота спауна
    // private float timer = 0;
    [SerializeField] private List<SheepProperty> sheepProperties;


    void Start()
    {
        StartCoroutine(SpawnSheep()); // Вызов каррутины
    }

    void CreateSheep() 
    {
        float xRandom = Random.Range(boundary.x, boundary.y);
        spawnPointPosition = new Vector3(xRandom, spawnPointPosition.y, spawnPointPosition.z);
        GameObject sheep = Instantiate(sheepPrefab, spawnPointPosition, sheepPrefab.transform.rotation); // Создаем овцу обект, на обекте есть компонент

        int randomSheepPropertyIndex = Random.Range(0, sheepProperties.Count);

        sheep.GetComponent<SheepMovement>().SetPropertyToSheep(sheepProperties[randomSheepPropertyIndex]);
    }

    IEnumerator SpawnSheep()
    {
        yield return new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            CreateSheep();
        }
        
    }
}
