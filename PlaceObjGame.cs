using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlaceObjGame : MonoBehaviour
{
    public Transform TheCamPos;
    public Transform[] CamPos;
    public GameObject PlaceCharHolder;
    public Cam TheCam;
    public GameObject DetailsObj;
    public string[] TheTitle;
    public TMP_Text TitleText;
    public TMP_Text NameText;
    public TMP_Text ExperienceText;
    public TMP_Text RelationText;
    public GameObject[] CoffetiObj;
    private void Start()
    {
        for(int i = 0; i < CoffetiObj.Length; i++)
        {
            CoffetiObj[i].SetActive(false);
        }
        ChangeCamPos(0);
    }
    private void Update()
    {
        MatchObj TheObj = GetComponent<MatchGame>().GetSelectedObj();
        if (TheObj != null)
        {
            //DetailsObj.SetActive(true);
            NameText.text = TheObj.GetComponent<MatchChar>().TheName;
            ExperienceText.text = TheObj.GetComponent<MatchChar>().Experience;
            RelationText.text = TheObj.GetComponent<MatchChar>().Relation;
        }
        else
        {
            DetailsObj.SetActive(false);
        }
    }
    public void ChangeCamPos(int Which)
    {
       
        StartCoroutine(DelayChange(Which));
    }
    IEnumerator DelayChange(int Which)
    {
        yield return new WaitForSeconds(2f);
        //TheCam.MoveSpeed = 2;
        TheCamPos.position = CamPos[Which].position;
        TheCamPos.rotation = CamPos[Which].rotation;
        TheCam.MatchPosCam = TheCamPos;
        PlaceCharHolder.transform.position = new Vector3(TheCamPos.position.x, PlaceCharHolder.transform.position.y, PlaceCharHolder.transform.position.z);
        GetComponent<MatchGame>().UpdateStartPos();
        TitleText.text = TheTitle[Which];

    }
    public void PlayConfetti(int Which)
    {
        //CoffetiObj[Which].SetActive(true);
        StartCoroutine(DelayEnable(CoffetiObj[Which]));

    }
    IEnumerator DelayEnable(GameObject TheObj)
    {
        yield return new WaitForSeconds(0.5f);
        TheObj.SetActive(true);
    }
}
