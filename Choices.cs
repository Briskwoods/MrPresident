using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choices : MonoBehaviour
{
    public TextMeshProUGUI ChoiceText;

    public void Pressed(int Which)
    {
        GetComponentInParent<DialogMan>().AnswerChoice(Which);
    }
}
