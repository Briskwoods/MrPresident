using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string TheQuestion="TheQuestion";
    public string[] TheQuestionSplit;
    public AudioClip[] TheAudiosMale;
    public AudioClip[] TheAudiosFemale;
    public AudioClip[] RepliesAudiosMale;
    public AudioClip[] RepliesAudiosFemale;
    public int WhichSplit;
    public bool IsChoiceQuiz;
    public string[] TheChoices=new string[2];
    public bool IsSwipeQuiz;
    public string SwipeText;
    public Sprite SwipeImg;
    public bool IsMatchQuiz;
    public string[] MatchText;
    public Sprite[] MatchImg;
    public bool IsGreeting;
    public Dialog[] SubDialog;
    public string WhichFunction;
    public GameObject ActivateObj;
    public GameObject DisableObj;
    public StaffCharacter[] ActiveStaff;
    public StaffCharacter[] LeavingStaff;
  public string GetSplit()
    {
        string Temp = "";
        if (WhichSplit > TheQuestionSplit.Length - 1)
        {
        }
        else
        {
            Temp= TheQuestionSplit[WhichSplit];
        }
        WhichSplit += 1;
        return Temp;
    }
}
