using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "ScriptableObjects/NewScoreManager")]
public class ScoreManager : ScriptableObject // �������� ������
{
    public int sheepSaved;
    public int sheepDropped;
    [SerializeField] private int sheepDropBeforeGameOver;
    
    public int SheepDropBeforeGameOver { get { return sheepDropBeforeGameOver; } }

    private void OnEnable()
    {
        sheepSaved = 0;
        sheepDropped = 0;
    }

    public void SaveSheep()
    {
        sheepSaved++;
    }

    public void DropSheep()
    {
        sheepDropped++;
    }


}
