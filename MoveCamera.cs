using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{

    public Transform CameraTarget;

    [ContextMenu("After Walk In")]
    public void AfterPresidentWalkIn()
    {
        transform.DOMove(CameraTarget.position, 1.5f).OnComplete(RotateCamera);
    }

    public void RotateCamera()
    {
        transform.DORotateQuaternion(CameraTarget.rotation, 1f).OnComplete(EnableCanvas);
    }


    public void EnableCanvas()
    {
        CodeManager.Instance.ScreenCanvas.SetActive(true);
        CodeManager.Instance.WorldCanvasController.CheckCounter();
    }
}
