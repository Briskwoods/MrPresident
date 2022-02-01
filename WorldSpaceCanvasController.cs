using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvasController : MonoBehaviour
{
    public Image Question1;
    public Image Question2;
    public Image Question3;

    public void CheckCounter()
    {
        switch (CodeManager.Instance.ScreenCanvasController.counter)
        {
            case 0:
                Question1.gameObject.SetActive(true);
                Question2.gameObject.SetActive(false);
                Question3.gameObject.SetActive(false);
                break;
            case 1:
                Question1.gameObject.SetActive(false);
                Question2.gameObject.SetActive(true);
                Question3.gameObject.SetActive(false);
                break;
            case 2:
                Question1.gameObject.SetActive(false);
                Question2.gameObject.SetActive(false);
                Question3.gameObject.SetActive(true);

                // Add Check/Trigger for End Level
                break;
        }
    }
}
