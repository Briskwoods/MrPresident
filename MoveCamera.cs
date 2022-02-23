using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{

    public Transform CameraTarget;
    public Transform CameraTarget2;

    [ContextMenu("After Walk In")]
    public void AfterPresidentWalkIn()
    {
        transform.DOMove(CameraTarget.position, 1.5f);
        Invoke("RotateCamera", 1f);
    }

    public void RotateCamera()
    {
        transform.DORotateQuaternion(CameraTarget.rotation, 1f).OnComplete(EnableCanvas);
    }

    public void EnableCanvas()
    {
        //CodeManager.Instance.ReportersController_.AllSit();
        CodeManager.Instance.WorldCanvasController.CheckCounter();
    }

    public void OnEndSequence()
    {
        transform.DOMove(CameraTarget2.position, 1.5f);
        transform.DORotateQuaternion(CameraTarget2.rotation, 1f).OnComplete(TriggerWinLose);
    }

    public void TriggerWinLose()
    {
        CodeManager.Instance.GameManager_.CheckWinLose();
    }
}
