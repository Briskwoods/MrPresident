using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMObstacleController : MonoBehaviour
{
    public CameraShakeScript CameraShakeScript_;
    public RunnerMinigameCameraController RunnerMinigameCameraController_;

    public float shakeTime;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "Player")
        {
            case true:
                StartCoroutine(ShakeCamera());
                break;
            case false:
                break;
        }
    }

    public IEnumerator ShakeCamera()
    {
        CameraShakeScript_.ShakeNow(shakeTime);
        yield return new WaitForSeconds(1f);
        StopCoroutine(ShakeCamera());
    }
}