using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMRunnerTrigger : MonoBehaviour
{
    public int count = 0;

    public GameObject objectToEnable;
    public Animator selfAnim;

    public RunnerMinigameController RunnerMinigameController_;


    private void Start()
    {
        selfAnim = this.gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.collider.tag == "Player")
        {
            case true:
                //Disable gamebject after enabling child on player

                objectToEnable.SetActive(true);
                selfAnim.SetTrigger("Disappear");
                switch(count == 0)
                {
                    case true:
                        RunnerMinigameController_.SupporterSize += 1;
                        count++;
                        break;
                    case false: break;
                }
                break;
            case false: break;
        }
    }

    public void DisableOnAnimationEnd()
    {
        this.gameObject.SetActive(false);
    }
}
