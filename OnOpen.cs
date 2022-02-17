using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOpen : MonoBehaviour
{
   public void OnOpenDoor()
    {
        //CodeManager.Instance.ReportersController_.AllStand();
        StartCoroutine(PauseBeforeWalkIn());
    }


    public IEnumerator PauseBeforeWalkIn()
    {
        yield return new WaitForSeconds(1f);
        CodeManager.Instance.PresidentController_.PresidentWalkIn();
        StopAllCoroutines();
    }
}
