using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSpaceCanvasController : MonoBehaviour
{
    public Slider m_popularityBar;

    public int counter = 0; 

    public void OnCorrectAnswer()
    {
        m_popularityBar.value += 1;
        counter++;
    }


    public void onWrongAnswer()
    {
        m_popularityBar.value -= 1;
        counter++;

    }
}
