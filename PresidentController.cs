using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PresidentController : MonoBehaviour
{
    public Transform PodiumTarget;

    [ContextMenu("Walk In")]
    public void PresidentWalkIn()
    {
        transform.DOMove(PodiumTarget.position, 3f).OnComplete(LookAtCrowd);
    }

    public void LookAtCrowd()
    {
        transform.DORotateQuaternion(PodiumTarget.rotation, 1f).OnComplete(CodeManager.Instance.MoveCamera_.AfterPresidentWalkIn);
    }
}
