using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PresidentController : MonoBehaviour
{
    public Transform PodiumTarget;

    public Transform Turn;

    public Animator m_presidentAnimator;

    [ContextMenu("Walk In")]
    public void PresidentWalkIn()
    {
        transform.DOMove(PodiumTarget.position, 5f).OnComplete(LookAtCrowd);
        m_presidentAnimator.SetBool("Walking", true);
        //CodeManager.Instance.ReportersController_.AllStand();
    }

    public void LookAtCrowd()
    {
        transform.DORotateQuaternion(PodiumTarget.rotation, 1f).OnComplete(CodeManager.Instance.MoveCamera_.AfterPresidentWalkIn);
        m_presidentAnimator.SetBool("Walking", false);
    }

    public void Win()
    {
        transform.DORotateQuaternion(Turn.rotation, 1f);
        m_presidentAnimator.SetTrigger("Win");
    }

    public void Lose()
    {
        m_presidentAnimator.SetTrigger("Lose");
    }
}
