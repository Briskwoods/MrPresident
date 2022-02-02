using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator m_DoorAnimator;

    [ContextMenu("Start")]
    public void StartSequence()
    {
        m_DoorAnimator.SetBool("Open", true);
    }

}
