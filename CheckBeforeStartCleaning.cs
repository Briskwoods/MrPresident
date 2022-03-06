using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBeforeStartCleaning : MonoBehaviour
{
    public bool isMalePresident;

    public GameObject malePresident;
    public GameObject femalePresident;

    private void Start()
    {
        CheckPresident();
    }

    public void CheckPresident()
    {
        // Get var saved in code controller
        isMalePresident = ControlManager.Instance.PlayerPrefs_Manager_Script.GetGender();

        // Check if male or female and basically change based on answer
        switch (isMalePresident)
        {
            case true:
                malePresident.SetActive(true);
                femalePresident.SetActive(false);
                break;
            case false:
                femalePresident.SetActive(true);
                malePresident.SetActive(false);
                break;
        }
    }
}
