using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportersController : MonoBehaviour
{
    public Animator[] m_allReporters;

    public void AllStand()
    {
        foreach(Animator reporter in m_allReporters)
        {
            reporter.SetBool("Stand", true);
        }
    }

    public void AllSit()
    {
        foreach (Animator reporter in m_allReporters)
        {
            reporter.SetBool("Stand", false);
        }
    }
}
