using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MatchGame : MonoBehaviour
{
    public MatchObj[] TheMatchs;
    public MatchTarget[] TheMatchTargets;
    public DialogMan TheDialog;
    public int count;
    float AnsweredTimestamp;
    bool Completed;
    bool Failed;
    public GameObject SuccessObj;
    public bool IsNonRules;
    public PlaceObjGame ThePlaceGame;
    // Start is called before the first frame update
    void Start()
    {
        if (TheDialog.ActiveDialog == null)
        {
            return;
        }
        if (TheDialog.ActiveDialog.IsMatchQuiz)
        {
            if (IsNonRules)
            {
                return;
            }
            for(int i = 0; i < TheMatchs.Length; i++)
            {
                TheMatchs[i].TheText.text = TheDialog.ActiveDialog.MatchText[i];
                TheMatchs[i].IconMesh.material.SetTexture("_MainTex", TheDialog.ActiveDialog.MatchImg[i].texture);
                TheMatchTargets[i].GetComponentInChildren<TMP_Text>().text = TheDialog.ActiveDialog.MatchText[i];


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Completed && AnsweredTimestamp < Time.time)
        {
            if (!Failed)
            {
                SuccessObj.SetActive(true);
            }
            Completed = false;
            TheDialog.NextStep();
        }
    }

    public void Finished(bool Correct)
    {
        if (Correct == false)
        {
            Failed = true;
        }
        if (ThePlaceGame != null)
        {
            ThePlaceGame.PlayConfetti(count);
        }
        count += 1;
        if (count > TheMatchTargets.Length - 1)
        {
            Completed = true;
            AnsweredTimestamp = Time.time + 1;
        }
        else
        {
            if (ThePlaceGame != null)
            {
                ThePlaceGame.ChangeCamPos(count);
            }
        }
    }
    public void WrongAnswer()
    {
        TheDialog.GetComponentInChildren<WrongAnswer>().shakeDuration = 1f;
        TheDialog.GetComponentInChildren<WrongAnswer>().TriggerWrongAnswer();
    }
    public void UpdateStartPos()
    {
        for(int i = 0; i < TheMatchs.Length; i++)
        {
            TheMatchs[i].StartPos = TheMatchs[i].transform.position;
        }
    }
    public MatchObj GetSelectedObj()
    {
        for (int i = 0; i < TheMatchs.Length; i++)
        {
            if (TheMatchs[i].Activated && !TheMatchs[i].finished)
            {
                return TheMatchs[i];
            }
        }
        return null;
    }
}
