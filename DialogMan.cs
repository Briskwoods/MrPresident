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
    public GameObject MatchHolder;
    public Transform MatchTrans;
    public Image MatchImg;
    public TMP_Text MatchText;
    public Dialog[] TheDialogLib;
    public GameObject DialogHolder;
    public Dialog ActiveDialog;
    public CharacterBehaviourManager TheChar;
    int ActiveDialogInt;
    public GameObject NextObj;
    public GameObject[] NextObjs;
    public GameObject Holder;
    public bool GameOver;
    public GameObject TapToContinueHolder;
    public GameObject ChoicesHolder;
    public TMP_Text DialogText;
    string ActiveQuiz;
    public StaffCharacter TheStaff;
    public AudioClip[] MaleGreeting;
    public AudioClip[] FemaleGreeting;
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
        if (Holder.activeSelf == false)
        {
            GetComponent<AudioSource>().Stop();
        }
      
        if (ActiveDialog != null) {
            DialogBubble.transform.position = Camera.main.WorldToScreenPoint(DialogPos.position);
            if (ActiveDialog.ActiveStaff.Length>0)
            {
                bool Deactivated = Holder.activeSelf;
                Holder.SetActive(ActiveDialog.ActiveStaff[0].Ready);
                if (Holder.activeSelf&&!Deactivated)
                {
                    if (!string.IsNullOrEmpty(ActiveQuiz))
                    {
                        DialogText.text = ActiveQuiz;
                        ActiveQuiz = "";
                    }
                    AnimateText();
                }
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
    public void PlayAudio(AudioClip _Clip)
    {
        GetComponent<AudioSource>().clip = _Clip;
        GetComponent<AudioSource>().Play();
    }
    public void GetDialog(bool IsSub,int WhichSub)
    {
        if (ActiveDialog != null)
        {
            if (ActiveDialog.ActivateObj != null)
            {
                ActiveDialog.ActivateObj.SetActive(true);
            }
            if (ActiveDialog.DisableObj != null)
            {
                ActiveDialog.DisableObj.SetActive(false);
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
        MatchHolder.SetActive(ActiveDialog.IsMatchQuiz);
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
        DialogText.text = ActiveDialog.TheQuestion;
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
        else if (ActiveDialog.IsMatchQuiz)
        {
           // MatchText.text = ActiveDialog.SwipeText;
            //MatchImg.sprite = ActiveDialog.SwipeImg;
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
                Camera.main.GetComponentInParent<Cam>().LookAtTarget = ActiveDialog.ActiveStaff[i].ModelHolder;

            }
            ActiveDialog.ActiveStaff[i].Enter();
        }
        for (int i = 0; i < ActiveDialog.LeavingStaff.Length; i++)
        {
            ActiveDialog.LeavingStaff[i].Exit();
        }
        if (Holder.activeSelf)
        {
            //AnimateText();
        }
        ChoicesHolder.SetActive(false);
        TapToContinueHolder.SetActive(false);
        TapToContinue();
    }
    public void AnimateText()
    {
        DialogBubble.GetComponentInChildren<AnimatedTyping>().Animate();
        float TheLenght = 0;
        if (ActiveDialog.IsGreeting&& ActiveDialog.WhichSplit<=1|| ActiveDialog.IsGreeting&&ActiveDialog.TheQuestionSplit.Length==0)
        {
            if (TheChar.isMale)
            {
                if (TheStaff.isMale)
                {
                    PlayAudio(MaleGreeting[0]);
                    TheLenght = MaleGreeting[0].length;
                }
                else
                {
                    PlayAudio(FemaleGreeting[0]);
                    TheLenght = MaleGreeting[0].length;
                }
            }
            else
            {
                if (TheStaff.isMale)
                {
                    PlayAudio(MaleGreeting[1]);
                    TheLenght = MaleGreeting[0].length;
                }
                else
                {
                    PlayAudio(FemaleGreeting[1]);
                    TheLenght = MaleGreeting[0].length;
                }
            }
        }
        StartCoroutine(PlayAudioDelayed(TheLenght));
        
    }
    IEnumerator PlayAudioDelayed(float TheT)
    {
        yield return new WaitForSeconds(TheT);
        if (TheStaff.isMale)
        {
            if (ActiveDialog.TheQuestionSplit.Length == 0)
            {
                PlayAudio(ActiveDialog.TheAudiosMale[0]);
            }
            else
            {
                PlayAudio(ActiveDialog.TheAudiosMale[ActiveDialog.WhichSplit - 1]);

            }
        }
        else
        {
            if (ActiveDialog.TheQuestionSplit.Length == 0)
            {
                PlayAudio(ActiveDialog.TheAudiosFemale[0]);
            }
            else
            {
                PlayAudio(ActiveDialog.TheAudiosFemale[ActiveDialog.WhichSplit - 1]);

            }
        }
    }
    public void AnswerChoice(int Which)
    {
        float TheLenght = 0.1f;
        if (ActiveDialog.RepliesAudiosFemale.Length > 0)
        {
            if (TheChar.isMale)
            {
                PlayAudio(ActiveDialog.RepliesAudiosMale[Which]);
                TheLenght = ActiveDialog.RepliesAudiosMale[Which].length;
            }
            else
            {
                PlayAudio(ActiveDialog.RepliesAudiosFemale[Which]);
                TheLenght = ActiveDialog.RepliesAudiosFemale[Which].length;
            }
        }
        StartCoroutine(AnswerDelayed(TheLenght, Which));
       

    }
    IEnumerator AnswerDelayed(float TheT,int Which)
    {
        ChoiceHolder.SetActive(false);
        yield return new WaitForSeconds(TheT);
        if (ActiveDialog.SubDialog[Which] == null)
        {
            ActiveDialogInt += 1;
            GetDialog(false, 0);
        }
        else
        {
            GetDialog(true, Which);

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
        float TheLenght = 0.1f;
        if (ActiveDialog.RepliesAudiosMale.Length > 0)
        {
            if (TheChar.isMale)
            {
                PlayAudio(ActiveDialog.RepliesAudiosMale[0]);
                TheLenght = ActiveDialog.RepliesAudiosMale[0].length;
            }
            else
            {
                PlayAudio(ActiveDialog.RepliesAudiosFemale[0]);
                TheLenght = ActiveDialog.RepliesAudiosFemale[0].length;
            }
        }
        //ActiveDialogInt += 1;
        StartCoroutine(AnswerDelayed(TheLenght, 0));
        //GetDialog(false, 0);
    }
    public void TapToContinue()
    {
        TapToContinueHolder.SetActive(false);
        string Temp = ActiveDialog.GetSplit();
        if (ActiveDialog.TheQuestionSplit.Length == 0&&
            ActiveDialog.WhichSplit==1)
        {
            ActiveDialog.WhichSplit += 1;
           Temp = ActiveDialog.TheQuestion;
        }
        if (string.IsNullOrEmpty(Temp))
        {
            ChoicesHolder.SetActive(true);
            return;
        }
        if (ActiveDialog.IsGreeting&&ActiveDialog.WhichSplit==1)
        {
            if (TheChar.isMale)
            {
                Temp = "Hello Mr " + Temp;
            }
            else
            {
                Temp = "Hello Madam " + Temp;
            }
        }
        DialogText.text =Temp;
        if (Holder.activeSelf)
        {
            ActiveQuiz = Temp;
            AnimateText();
        }
    }
    
}
