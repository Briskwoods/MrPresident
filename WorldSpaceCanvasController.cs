using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvasController : MonoBehaviour
{
    public Image Question1;
    public Image Question2;
    public Image Question3;

    //public Animator m_Reporter1;
    //public Animator m_Reporter2;
    //public Animator m_Reporter3;



    public void CheckCounter()
    {
        switch (CodeManager.Instance.ScreenCanvasController.counter)
        {
            case 0:
                StartCoroutine(PauseBeforeAskingQuestion1());
                break;
            case 1:
                //m_Reporter2.SetBool("Stand", true);
                StartCoroutine(PauseBeforeAskingQuestion2());
                //m_Reporter1.SetBool("Stand", false);
                break;
            case 2:
                //m_Reporter3.SetBool("Stand", true);
                StartCoroutine(PauseBeforeAskingQuestion3());
                //m_Reporter2.SetBool("Stand", false);
                break;
            case 3:
                StartCoroutine(FinalAnswer());
                break;
        }
    }

    public IEnumerator PauseBeforeAskingQuestion1()
    {
        yield return new WaitForSeconds(1f);
        //m_Reporter1.SetBool("Stand", true);
        //yield return new WaitForSeconds(2f);
        //CodeManager.Instance.ScreenCanvasController.m_popularityBar.gameObject.SetActive(true);
        CodeManager.Instance.ScreenCanvasController.m_democratOption1.SetActive(true);
        CodeManager.Instance.ScreenCanvasController.m_republicanOption1.SetActive(true);
        Question1.gameObject.GetComponent<Animator>().SetTrigger("Open");
        StopAllCoroutines();
    }

    public IEnumerator PauseBeforeAskingQuestion2()
    {
        Question1.gameObject.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(3f);
        CodeManager.Instance.ScreenCanvasController.m_democratOption2.SetActive(true);
        CodeManager.Instance.ScreenCanvasController.m_republicanOption2.SetActive(true);
        Question2.gameObject.GetComponent<Animator>().SetTrigger("Open");
        StopAllCoroutines();
    }

    public IEnumerator PauseBeforeAskingQuestion3()
    {
        Question2.gameObject.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(3f);
        CodeManager.Instance.ScreenCanvasController.m_democratOption3.SetActive(true);
        CodeManager.Instance.ScreenCanvasController.m_republicanOption3.SetActive(true);
        Question3.gameObject.GetComponent<Animator>().SetTrigger("Open");
        StopAllCoroutines();
    }

    public IEnumerator FinalAnswer()
    {
        //m_Reporter3.SetBool("Stand", false);
        Question3.gameObject.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(2.5f);
        CodeManager.Instance.MoveCamera_.OnEndSequence();
    }
}
