using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IndividualController : MonoBehaviour
{
    public bool m_isRepublican = false;

    public Transform m_target;
    public Animator m_self;

    public Rigidbody m_shoe;

    public float Force = 100f;
    public float m_throwHeight = 100f;

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

    public void Throw()
    {
        m_shoe = Instantiate(m_shoe, this.gameObject.transform.position + new Vector3(0,3,0), this.gameObject.transform.rotation);         
        m_shoe.AddForce((m_shoe.transform.forward + new Vector3(0, m_throwHeight, 0)) * Force, ForceMode.Impulse);       
        m_shoe.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); 
    }

}
