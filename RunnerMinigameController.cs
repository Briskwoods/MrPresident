using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMinigameController : MonoBehaviour
{
    public CharacterBehaviourManager Character_;
    public List<Animator> runners = new List<Animator>();

    public Transform MoneySpawnPoint;

    public int SupporterSize = 0;
    public int endGoal = 7;

    public void CheckWin() {

        switch (SupporterSize == endGoal)
        {
            case true:

                Character_.SetAnimation("Dance");

                foreach (Animator runner in runners)
                {
                    runner.SetTrigger("Dance");
                }

                ControlManager.Instance.EconomyManager_Script.IncreaseEconomy(50, MoneySpawnPoint.position);
                break;
            case false:

                Character_.SetAnimation("Lose");

                foreach (Animator runner in runners)
                {
                    runner.SetTrigger("Lose");
                }
                Debug.Log("Lose");
                break;
        }
    }

}
