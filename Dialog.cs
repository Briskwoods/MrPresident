using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string TheQuestion="TheQuestion";
    public bool IsChoiceQuiz;
    public string[] TheChoices=new string[2];
    public bool IsSwipeQuiz;
    public string SwipeText;
    public Sprite SwipeImg;
    public bool IsGreeting;
    public Dialog[] SubDialog;
    public string WhichFunction;
    public GameObject ActivateObj;
    public StaffCharacter[] ActiveStaff;
    public StaffCharacter[] LeavingStaff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
