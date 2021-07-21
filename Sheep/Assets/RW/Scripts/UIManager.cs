using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // ���������� ��� �������� ������ �� �����
    [SerializeField] private TextMeshProUGUI saveSheepText;
    [SerializeField] private TextMeshProUGUI dropSheepText;
    // �������� ������ �� Scoremanager;
    [SerializeField] private ScoreManager scoreManager;

    public void UpdateScore()
    {
        // ��������� �����
        //saveSheepText.text = "";
        // dropSheepText.text = "";

        // ��������� �� ������
        saveSheepText.text = scoreManager.sheepSaved.ToString();
        dropSheepText.text = scoreManager.sheepDropped.ToString();

        if (scoreManager.sheepDropped > scoreManager.SheepDropBeforeGameOver)
        {
            Debug.Log("Game Over");
        }
    }
}
