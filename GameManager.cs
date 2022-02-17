using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Animator m_DoorAnimator;

    public bool m_isRepublican = false;

    public CrowdController m_crowd1; 
    public CrowdController m_crowd2; 
    public CrowdController m_crowd3;

    public GameObject m_redConfetti;
    public GameObject m_blueConfetti;

    public Button m_nextLevel;

    [ContextMenu("Start")]
    public void StartSequence()
    {
        //m_DoorAnimator.SetBool("Open", true);
    }

    public void CheckWinLose()
    {
        switch (m_isRepublican)                                            // So (m_isRepublican = true) is Republican Side and (m_isRepublic = false) is Democrat Side
        {
            case true:
                switch(CodeManager.Instance.ScreenCanvasController.m_popularityBar.value > 0)
                {
                    case true:
                        CodeManager.Instance.PresidentController_.Win();
                        m_crowd1.CheckWinLose();
                        m_crowd2.CheckWinLose();
                        m_crowd3.CheckWinLose();
                        m_nextLevel.gameObject.SetActive(true);
                        m_blueConfetti.SetActive(true);
                        break;
                    case false:
                        CodeManager.Instance.PresidentController_.Lose();
                        m_crowd1.CheckWinLose();
                        m_crowd2.CheckWinLose();
                        m_crowd3.CheckWinLose();
                        m_nextLevel.gameObject.SetActive(true);
                        break;
                }
                break;
            case false:
                switch (CodeManager.Instance.ScreenCanvasController.m_popularityBar.value < 0)
                {
                    case true:
                        CodeManager.Instance.PresidentController_.Win();
                        m_crowd1.CheckWinLose();
                        m_crowd2.CheckWinLose();
                        m_crowd3.CheckWinLose();
                        m_nextLevel.gameObject.SetActive(true);
                        m_redConfetti.SetActive(true);
                        break;
                    case false:
                        CodeManager.Instance.PresidentController_.Lose();
                        m_crowd1.CheckWinLose();
                        m_crowd2.CheckWinLose();
                        m_crowd3.CheckWinLose();
                        m_nextLevel.gameObject.SetActive(true);
                        break;
                }
                break;
        }
    }
}
