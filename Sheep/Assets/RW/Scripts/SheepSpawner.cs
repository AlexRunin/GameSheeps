using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private string objectTag; // ссылка на tag

    //[SerializeField] private GameObject sheepPrefab;
    [SerializeField] private Vector3 spawnPointPosition;
    [SerializeField] private Vector2 boundary; //граница
    [SerializeField] private float spawnRate; //чистота спауна
    // private float timer = 0;
    [SerializeField] private List<SheepProperty> sheepProperties;
    [SerializeField] private int sheepCount;
    [SerializeField] private int waveCount;
    [SerializeField] private float waveRate;


    //[SerializeField] public int sheepCountWave; // Кол-во овец в волне
    //[SerializeField] public float startWait; // Время ожидания для старта
    //[SerializeField] public float waveWaite; // Задержка между волнами

    //[SerializeField] private Vector3 spawnPoint_1;
    //[SerializeField] private Vector3 spawnPoint_2;
    //[SerializeField] private Vector3 spawnPoint_3;
    
    

    void Start()
    {
        //StartCoroutine(CreateSpawnSheep()); // Вызов каррутины
        //SpawnSheepPoint();
        StartCoroutine(SpawnSheep());
    }

    void CreateSheep()
    {
        float xRandom = Random.Range(boundary.x, boundary.y);
        spawnPointPosition = new Vector3(xRandom, spawnPointPosition.y, spawnPointPosition.z);
        GameObject sheep = ObjectPooler.objectPooler.GetPooledObject(objectTag); // создаем игровой объект
        if (sheep == null)
        {
            return;
        }

        sheep.transform.position = spawnPointPosition;
        sheep.SetActive(true); // активируем овечку

        //GameObject sheep = Instantiate(sheepPrefab, spawnPointPosition, sheepPrefab.transform.rotation);

        int randomSheepPropertyIndex = Random.Range(0, sheepProperties.Count);
        sheep.GetComponent<SheepMovement>().SetPropertyToSheep(sheepProperties[randomSheepPropertyIndex]);
    }


    //IEnumerator CreateSpawnSheep() 
    //{
    //    yield return new WaitForSeconds(startWait);

    //    while (true)
    //    {
    //        for (int i = 0; i < sheepProperties.Count; i ++)
    //        {
    //            float xRandom = Random.Range(boundary.x, boundary.y);
    //            spawnPointPosition = new Vector3(xRandom, spawnPointPosition.y, spawnPointPosition.z);
    //            GameObject sheep = Instantiate(sheepPrefab, spawnPointPosition, sheepPrefab.transform.rotation); // Создаем овцу обект, на обекте есть компонент
    //            int randomSheepPropertyIndex = Random.Range(0, sheepProperties.Count);
    //            sheep.GetComponent<SheepMovement>().SetPropertyToSheep(sheepProperties[randomSheepPropertyIndex]);

    //            yield return new WaitForSeconds(Random.Range(0.5f, spawnRate));
    //        }
    //        yield return new WaitForSeconds(waveWaite);


    //        sheepProperties.Add((new SheepProperty()));

    //    }
    //}

    IEnumerator SpawnSheep()
    {
        yield return new WaitForSeconds(spawnRate);

        while (waveCount > 0)
        {
            for (int i = 0; i < sheepCount; i++)
            {
                yield return new WaitForSeconds(spawnRate);
                CreateSheep();
            }

            sheepCount += 5; // увеличение на след волне
            waveCount--;
            yield return new WaitForSeconds(waveRate);
        }

        Debug.Log("Finish. You win!");
    }

    void SpawnSheepPoint()
    {
        //float pointRandom = Random.Range(spawnPoint_1, spawnPoint_2, spawnPoint_3);
        //spawnPointPosition = new Vector3(xRandom, spawnPointPosition.y, spawnPointPosition.z);

        //yield return new WaitForSeconds(startWait);

        //while (true)
        //{
        //    for (int i = 0; i < sheepProperties.Count; i++)
        //    {
                //GameObject sheep = Instantiate(sheepPrefab, spawnPointPosition, sheepPrefab.transform.rotation); // Создаем овцу обект, на обекте есть компонент
               // int randomSheepPropertyIndex = Random.Range(0, sheepProperties.Count);
                //sheep.GetComponent<SheepMovement>().SetPropertyToSheep(sheepProperties[randomSheepPropertyIndex]);

            //    yield return new WaitForSeconds(spawnRate);
                
            //}
            //CreateSheep();
            //yield return new WaitForSeconds(waveWaite);
            
        }
    }

