using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropMinigameController : MonoBehaviour
{
    public List<SnapToPosition> Positions = new List<SnapToPosition>();
    public List<DnDPenHolderController> PenPositions = new List<DnDPenHolderController>();

    public Transform MoneySpawnPoint;


    public void CheckWin()
    {
        switch(Positions.Count == 0 && PenPositions.Count == 0)
        {
            case true:
                Debug.Log("Win");
                ControlManager.Instance.EconomyManager_Script.IncreaseEconomy(50, MoneySpawnPoint.position);
                break;
            case false: break;
        }
    }
}
