using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MatchChar : MonoBehaviour
{
    public string TheName;
    public string Experience;
    public string Relation;
    public TMP_Text NameText;
    public TMP_Text ExperienceText;
    public TMP_Text RelationText;
    public GameObject PaperHolder;
    public Transform TheHips;
    // Start is called before the first frame update
    void Start()
    {
        PaperHolder.transform.SetParent(TheHips);
    }

    // Update is called once per frame
    void Update()
    {
        NameText.text = TheName;
        ExperienceText.text = Experience;
        RelationText.text = Relation;
        if (GetComponent<MatchObj>().finished)
        {
            PaperHolder.SetActive(false);
            PlayAnimation("Dance");
        }
        else if (GetComponent<MatchObj>().Activated)
        {
            PaperHolder.SetActive(false);
            PlayAnimation("Floating");
        }
        else
        {
            PaperHolder.SetActive(true);
            PlayAnimation("Idle");
        }
        if (Input.GetButtonDown("Fire1") && GetComponent<MatchObj>().SelectedCoolTimestamp<Time.time)
        {
            GetComponent<MatchObj>().ResetG();
        }
    }
    public void PlayAnimation(string animation_name)
    {
        GetComponentInChildren<Animator>().Play(animation_name);
    }
}
