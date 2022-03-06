using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogMan : MonoBehaviour
{
    public GameObject DialogBubble;
    public Transform DialogPos;
    public GameObject ChoiceHolder;
    public Choices[] TheChoices;
    public GameObject SwipeHolder;
    public Transform SwipeTrans;
    public Image SwipeImg;
    public TMP_Text SwipeText;
    public Dialog[] TheDialogLib;
    public GameObject DialogHolder;
    public Dialog ActiveDialog;
    public CharacterBehaviourManager TheChar;
    int ActiveDialogInt;
    public GameObject NextObj;
    public GameObject[] NextObjs;
    public GameObject Holder;
    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        TheDialogLib = DialogHolder.GetComponentsInChildren<Dialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Holder.SetActive(false);
            return;

        }
        if (ActiveDialog != null) {
            DialogBubble.transform.position = Camera.main.WorldToScreenPoint(DialogPos.position);
            if (ActiveDialog.ActiveStaff.Length>0)
            {
                Holder.SetActive(ActiveDialog.ActiveStaff[0].Ready);
            }
            else
            {
                Holder.SetActive(true);
            }

        }
        else
        {
            Holder.SetActive(false);
        }
        if (TheChar.Initialized)
        {
            if (ActiveDialog == null)
            {
                GetDialog(false,0);
            }
        }
    }
    public void GetDialog(bool IsSub,int WhichSub)
    {
        if (ActiveDialog != null)
        {
            if (ActiveDialog.ActivateObj != null)
            {
                ActiveDialog.ActivateObj.SetActive(true);
            }
        }
        if (IsSub)
        {
            ActiveDialog = ActiveDialog.SubDialog[WhichSub];
        }
        else
        {
            if (ActiveDialogInt > TheDialogLib.Length - 1)
            {
                GameOver = true;
                return;
            }
            ActiveDialog = TheDialogLib[ActiveDialogInt];
        }
        ChoiceHolder.SetActive(ActiveDialog.IsChoiceQuiz);
        SwipeHolder.SetActive(ActiveDialog.IsSwipeQuiz);
        if (ActiveDialog.IsGreeting)
        {
            string Temp = ActiveDialog.TheQuestion;
            if (TheChar.isMale)
            {
                Temp = "Hello Mr " + Temp;
            }
            else
            {
                Temp = "Hello Madam " + Temp;
            }
            ActiveDialog.TheQuestion = Temp;
        }
        DialogBubble.GetComponentInChildren<TMP_Text>().text = ActiveDialog.TheQuestion;
        if (ActiveDialog.IsChoiceQuiz)
        {
            TheChoices[0].ChoiceText.SetText(ActiveDialog.TheChoices[0]);
            TheChoices[1].ChoiceText.SetText(ActiveDialog.TheChoices[1]);

            NextObj.SetActive(false);
        }
        else if (ActiveDialog.IsSwipeQuiz)
        {
            SwipeText.text = ActiveDialog.SwipeText;
            SwipeImg.sprite = ActiveDialog.SwipeImg;
            NextObj.SetActive(false);
        }
        else
        {
            NextObj.SetActive(true);
            int ActiveOne = 0;
            if (string.IsNullOrEmpty(ActiveDialog.WhichFunction))
            {
                ActiveOne = 0;
            }else if (ActiveDialog.WhichFunction=="Collect")
            {
                ActiveOne = 1;
            }
            for (int i = 0; i < NextObjs.Length; i++)
            {
                NextObjs[i].SetActive(false);
            }
            NextObjs[ActiveOne].SetActive(true);
        }
        for(int i = 0; i < ActiveDialog.ActiveStaff.Length; i++)
        {
            if (i == 0)
            {
                Camera.main.GetComponent<Cam>().LookAtTarget = ActiveDialog.ActiveStaff[i].ModelHolder;

            }
            ActiveDialog.ActiveStaff[i].Enter();
        }
        for (int i = 0; i < ActiveDialog.LeavingStaff.Length; i++)
        {
            ActiveDialog.LeavingStaff[i].Exit();
        }
    }
    public void AnswerChoice(int Which)
    {
        if (ActiveDialog.SubDialog[Which] == null)
        {
            ActiveDialogInt += 1;
            GetDialog(false,0);
        }
        else
        {
            GetDialog(true,Which);

        }
    }
    public void AnswerSwipe(int Which)
    {
        if (ActiveDialog.SubDialog[Which] == null)
        {
            ActiveDialogInt += 1;
            GetDialog(false,0);
        }
        else
        {
            GetDialog(true,Which);

        }
    }
    public void NextStep()
    {
       
        ActiveDialogInt += 1;
        GetDialog(false, 0);
    }
}
