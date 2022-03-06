using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
{
    public List<ZoneController> zones = new List<ZoneController>();
    public Transform MoneySpawnPoint;
    public Animator FrameAnim;
    bool CallOnce = false;


    public void CheckIfDone()
    {
        foreach (ZoneController zone in zones)
        {
            switch (zone.isTaken)
            {
                case true:
                    zones.Remove(zone);
                    break;
                case false: break;
            }
        }


        switch(zones.Count == 0 && !CallOnce)
        {
            case true:
                Invoke("PutFrameBack", 2f);
                CallOnce = true;
                ControlManager.Instance.EconomyManager_Script.IncreaseEconomy(50, MoneySpawnPoint.position);
                break;
            case false: break;
        }
    }

    public void PutFrameBack() 
    {
        FrameAnim.SetTrigger("Back");

        Invoke("NextLevel", 3f);
    }

    public void NextLevel()
    {
        ControlManager.Instance.LevelManager_Script.NextLevel();
    }
}
