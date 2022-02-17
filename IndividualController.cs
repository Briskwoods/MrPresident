using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IndividualController : MonoBehaviour
{
    public bool m_isRepublican = false;

    public Transform m_target;
    public Animator m_self;

    private void Start()
    {
        m_self = this.gameObject.GetComponent<Animator>();
    }

    [ContextMenu("Test")]
    public void Move()
    {
        transform.LookAt(m_target);
        transform.DOMove(m_target.position, 5f).OnComplete(LookAtPresident);
        m_self.SetBool("Run", true);
        //transform.DORotateQuaternion(m_target.rotation, 1f);

    }

    public void LookAtPresident()
    {
        m_self.SetBool("Run", false);
        transform.DORotateQuaternion(m_target.rotation, 1f);

    }
}
