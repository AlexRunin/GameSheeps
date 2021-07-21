using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // переменная для хранения ссылки на текст
    [SerializeField] private TextMeshProUGUI saveSheepText;
    [SerializeField] private TextMeshProUGUI dropSheepText;
    // Получаем данные от Scoremanager;
    [SerializeField] private ScoreManager scoreManager;

    public void UpdateScore()
    {
        // Обновляем текст
        //saveSheepText.text = "";
        // dropSheepText.text = "";

        // Обновляем на экране
        saveSheepText.text = scoreManager.sheepSaved.ToString();
        dropSheepText.text = scoreManager.sheepDropped.ToString();

        if (scoreManager.sheepDropped > scoreManager.SheepDropBeforeGameOver)
        {
            Debug.Log("Game Over");
        }
    }
}
