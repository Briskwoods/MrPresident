using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvasController : MonoBehaviour
{
    public Image Question1;
    public Image Question2;
    public Image Question3;

    public Animator m_Reporter1;
    public Animator m_Reporter2;
    public Animator m_Reporter3;



    public void CheckCounter()
    {
        switch (CodeManager.Instance.ScreenCanvasController.counter)
        {
            case 0:
                StartCoroutine(PauseBeforeAskingQuestion1());
                break;
            case 1:
                m_Reporter2.SetBool("Stand", true);
                StartCoroutine(PauseBeforeAskingQuestion2());
                m_Reporter1.SetBool("Stand", false);
                break;
            case 2:
                m_Reporter3.SetBool("Stand", true);
                StartCoroutine(PauseBeforeAskingQuestion3());
                m_Reporter2.SetBool("Stand", false);
                break;
        }
    }

    public IEnumerator PauseBeforeAskingQuestion1()
    {
        yield return new WaitForSeconds(1f);
        m_Reporter1.SetBool("Stand", true);
        yield return new WaitForSeconds(2f);
        CodeManager.Instance.ScreenCanvas.SetActive(true);
        Question1.gameObject.SetActive(true);
        StopAllCoroutines();
    }

    public IEnumerator PauseBeforeAskingQuestion2()
    {
        Question1.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        CodeManager.Instance.ScreenCanvas.SetActive(true);
        Question2.gameObject.SetActive(true);
        StopAllCoroutines();
    }

    public IEnumerator PauseBeforeAskingQuestion3()
    {
        Question1.gameObject.SetActive(false);
        Question2.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        CodeManager.Instance.ScreenCanvas.SetActive(true);
        Question3.gameObject.SetActive(true);
        StopAllCoroutines();
    }
}
