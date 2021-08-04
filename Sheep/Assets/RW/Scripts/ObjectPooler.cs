using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // ссылки которые мы создадим в этом классе будут редактируемые в ИНСПЕКТОРЕ
public class ObjectPoolItem
{
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;
}

public class ObjectPooler : MonoBehaviour
{
    // [SerializeField] private GameObject pooledObject; // сам префаб
    //[SerializeField] private int pooledAmount; // колличество
    //[SerializeField] private bool willGrow; // для расширения, если кончились(надоли пулу расти)
    public static ObjectPooler objectPooler; // ссылка самих на себя (на прямую имеимдоступ отовсюду)
    [SerializeField] private List<GameObject> pooledObjects; // список объектов которые будут помещены в пулл
    [SerializeField] private List<ObjectPoolItem> itemsToPool; // список Items

    private void Awake()
    {
        objectPooler = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.pooledAmount; i++)
            {
                pooledObjects.Add(Instantiate(item.pooledObject)); // pooledObject - Prefab
                pooledObjects[i].transform.SetParent(transform);
                pooledObjects[i].SetActive(false);
            }
        }
        
    }

    // ПЕРЕДАЕМ СОЗДАННЫЕ ОБЪЕКТЫ В ДРУГИХ СКРИПТАХ
    public GameObject GetPooledObject(string tag) // МЕТОД АКТИВАЦИИ ОБЪЕКТА
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) // pooledObjects[i].activeInHierarchy == false
            {
                return pooledObjects[i]; // возвращяем выбранный элемент
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.pooledObject.tag == tag)
            {
                if (item.willGrow) //willGrow == true
                {
                    // создаем объект
                    GameObject obj = Instantiate(item.pooledObject);// создаем локально GameObject
                    obj.SetActive(false); // диактивация самого объекта
                    pooledObjects.Add(obj);  // добавили в список
                    obj.transform.SetParent(transform);

                    return obj;
                }
            }
        }
        return null;
    }
}
