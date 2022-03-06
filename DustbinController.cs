using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustbinController : MonoBehaviour
{

    public DustbinMinigameController dustbinMinigameController_;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "Paper")
        {
            case true:
                dustbinMinigameController_.currentScore += 1;
                dustbinMinigameController_.CheckWin();
                break;
            case false:
                break;
        }
    }
}
