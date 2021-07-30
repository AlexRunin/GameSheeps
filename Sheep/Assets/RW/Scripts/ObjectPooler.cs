using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler objectPooler; // ссылка самих на себя (на прямую имеимдоступ отовсюду)
    [SerializeField] private GameObject pooledObject; // сам префаб
    [SerializeField] private int pooledAmount; // колличество
    [SerializeField] private bool willGrow; // для расширения, если кончились(надоли пулу расти)

    [SerializeField] List<GameObject> pooledObjects; // список объектов которые будут помещены в пулл

    private void Awake()
    {
        objectPooler = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            pooledObjects.Add(Instantiate(pooledObject)); // pooledObject - Prefab
            pooledObjects[i].transform.SetParent(transform);
            pooledObjects[i].SetActive(false);
        }
    }

    // ПЕРЕДАЕМ СОЗДАННЫЕ ОБЪЕКТЫ В ДРУГИХ СКРИПТАХ
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) // pooledObjects[i].activeInHierarchy == false
            {
                return pooledObjects[i]; // возвращяем выбранный элемент
            }
        }
        if (willGrow) //willGrow == true
        {
            // создаем объект
            GameObject obj = Instantiate(pooledObject);// создаем локально GameObject
            pooledObjects.Add(obj);  // добавили в список
            obj.transform.SetParent(transform);

            return obj;
        }

        return null;
    }
}
