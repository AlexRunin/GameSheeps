using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDestroyer : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private ScoreManager scoreManager; // Получаем ссылку на наш ScripticleObject
    [SerializeField] private GameEvent droppedSheepEvent; //само сабытие

    private void OnTriggerExit(Collider other)
    {
        SheepMovement sheepMovement = other.GetComponent<SheepMovement>();

        if (sheepMovement != null)
        {
            soundManager.PlayDropClip();
            other.GetComponent<Rigidbody>().isKinematic = false;
            //Destroy(other.gameObject, 3f);

            StartCoroutine(DeactivateSheep(sheepMovement.gameObject));

            scoreManager.DropSheep();

            droppedSheepEvent.Raise(); 
        }
    }

    IEnumerator DeactivateSheep(GameObject sheep)
    {
        yield return new WaitForSeconds(3f);
        sheep.gameObject.SetActive(false);
        sheep.GetComponent<Rigidbody>().isKinematic = true;
    }
}
