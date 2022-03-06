using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public bool isDart = false;

    [SerializeField] private Transform m_throwPoint;

    [SerializeField] private float Force = 10f;

    public float ThrowForceInZ = 50f;

    [SerializeField] private float m_throwHeight;

    [SerializeField] private Rigidbody originalThrowable;

    [SerializeField] private Rigidbody m_ObjectToThrow;

    public GameObject Paper;


    public void Throw(float inputForceX,float inputForceY)
    {
        switch(isDart)
        {
            case true:
                m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_ObjectToThrow.transform.rotation); // Instantiate Stick to throw at hand position        
                break;
            case false:
                m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_throwPoint.transform.rotation); // Instantiate Stick to throw at hand position        
                break;
        }

        m_ObjectToThrow.AddForce((m_ObjectToThrow.transform.forward + new Vector3(inputForceX, m_throwHeight, ThrowForceInZ)) * Force, ForceMode.Impulse);// Add force in the Z direction (forward)        
        switch (isDart)
        {
            case true:
                break;
            case false:
                m_ObjectToThrow.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite
                break;
        }
        StartCoroutine(DelayAfterThrow(0.5f));
    }

    IEnumerator DelayAfterThrow(float seconds)
    {
        m_ObjectToThrow = originalThrowable; // Control Variable
        Paper.SetActive(false);
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
        Paper.SetActive(true);
        StopCoroutine(DelayAfterThrow(0f));

    }
}
