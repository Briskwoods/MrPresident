using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public DartMinigameController DartMinigameController_;

    public ParticleSystem startBurst;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag == "Dart")
        {
            case true:
                collision.collider.gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
                collision.collider.gameObject.transform.parent.localScale *=3;
                startBurst.Play();
                DartMinigameController_.currentScore += 1;
                DartMinigameController_.CheckWin();
                StartCoroutine(DelayBeforeDisable(0.5f));
                break;
            case false:
                break;
        }
    }

    IEnumerator DelayBeforeDisable(float seconds)
    {
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again
        this.gameObject.SetActive(false);
        StopCoroutine(DelayBeforeDisable(0f));

    }
}
