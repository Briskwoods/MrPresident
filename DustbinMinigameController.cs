using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DustbinMinigameController : MonoBehaviour
{
    public int goal = 3;
    public int currentScore = 0;

    public Transform MoneySpawnPoint;

    public ParticleSystem startBurst;

    public Slider Score;

    public void CheckWin()
    {
        switch (currentScore == goal)
        {
            case true:
                Score.DOValue(currentScore, 0.5f);
                startBurst.Play();
                Debug.Log("Win!");
                ControlManager.Instance.EconomyManager_Script.IncreaseEconomy(50, MoneySpawnPoint.position);

                Invoke("NewLevel", 3f);
                break;
            case false:
                Score.DOValue(currentScore, 0.5f);
                startBurst.Play();
                break;
        }
    }

    public void NewLevel()
    {
        ControlManager.Instance.LevelManager_Script.NextLevel();
    }
}
