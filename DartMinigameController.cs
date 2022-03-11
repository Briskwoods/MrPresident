using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class DartMinigameController : MonoBehaviour
{
    public int goal = 3;
    public int currentScore = 0;

    public Transform MoneySpawnPoint;

    public Slider Score;

    public void CheckWin()
    {
        switch (currentScore == goal)
        {
            case true:
                Score.DOValue(currentScore, 0.5f);
                Debug.Log("Win!");
                ControlManager.Instance.EconomyManager_Script.IncreaseEconomy(50, MoneySpawnPoint.position);

                Invoke("NewLevel", 3f);
                break;
            case false:
                Score.DOValue(currentScore, 0.5f);
                break;
        }
    }

    public void NewLevel()
    {
        ControlManager.Instance.LevelManager_Script.NextLevel();
    }
}


