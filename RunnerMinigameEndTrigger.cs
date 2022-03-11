using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMinigameEndTrigger : MonoBehaviour
{
    public PlayerMovement playerMovement;


    public RunnerMinigameController RunnerMinigameController_;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Player")
        {
            case true:
                playerMovement.m_isStopped = true;
               
                RunnerMinigameController_.CheckWin();
                break;
            case false:
                break;
        }
    }
}
