using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSpaceCanvasController : MonoBehaviour
{
    public Slider m_popularityBar;

    //public GameObject m_CorrectButton;
    //public GameObject m_WrongButton;

    public GameObject m_republicanOption1;
    public GameObject m_democratOption1;

    public GameObject m_republicanOption2;
    public GameObject m_democratOption2;

    public GameObject m_republicanOption3;
    public GameObject m_democratOption3;

    public int counter = 0; 

    public void OnRepublicanAnswer()
    {
        m_popularityBar.value += 1;
        counter++;
    }


    public void OnDemocratAnswer()
    {
        m_popularityBar.value -= 1;
        counter++;

    }
}
