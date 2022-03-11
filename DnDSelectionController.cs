using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDSelectionController : MonoBehaviour
{
    public bool isSelected = false;
    public Outline Goal;

    public void CheckIfSelected()
    {
        switch (isSelected)
        {
            case true:
                Goal.enabled = true;
                break;
            case false:
                Goal.enabled = false;
                break;
        }
    }
}
