using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MatchObj : MonoBehaviour
{
    public Vector3 StartPos;
    float offset;
    public Transform TargetPos;
    public bool Activated;
    public bool finished;
    public MeshRenderer IconMesh;
    public TMP_Text TheText;
    public GameObject ResultObj;
    public GameObject YesObj;
    public GameObject NoObj;
    float ErrorTimestamp;
    public float MinDist = 0.1f;
    public float HeightOffset = 0.1f;
    public float SelectedCoolTimestamp;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
       /// TargetPos.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MatchObj TheObj = GetComponentInParent<MatchGame>().GetSelectedObj();
        if (TheObj != null)
        {
            GetComponent<BoxCollider>().enabled =false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }
       // GetComponent<BoxCollider>().enabled = !Activated;
        if (!Activated)
        {
            if (!finished)
            {
                Vector3 pos = new Vector3(transform.position.x, StartPos.y, transform.position.z);
                //transform.position = pos;
                transform.position = Vector3.Lerp(transform.position, StartPos, 5 * Time.deltaTime);
                if (ErrorTimestamp<Time.time)
                {
                    ResultObj.SetActive(false);
                }
            }
            else
            {
                //Vector3 pos = new Vector3(transform.position.x, StartPos.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position,TargetPos.position,5*Time.deltaTime);
            }
            return;
        }
        for(int i = 0; i < GetComponentInParent<MatchGame>().TheMatchTargets.Length; i++)
        {
            Transform Pos = GetComponentInParent<MatchGame>().TheMatchTargets[i].transform;
            if (Pos.GetComponent<MatchTarget>().Filled==null&&
                Vector3.Distance(transform.position, new Vector3(Pos.position.x, transform.position.y, Pos.position.z)) < MinDist)
            {
                Activated = false;
                ResultObj.SetActive(true);
                if (TargetPos == Pos||GetComponentInParent<MatchGame>().IsNonRules)
                {
                    GetComponentInParent<MatchGame>().Finished(true);
                    YesObj.SetActive(true);
                    finished = true;
                    Pos.GetComponent<MatchTarget>().Filled = gameObject;
                    TargetPos = Pos;
                    if (GetComponentInParent<MatchGame>().IsNonRules)
                    {
                        transform.SetParent(GetComponentInParent<MatchGame>().transform);
                    }

                }
                else
                {
                    ErrorTimestamp = Time.time + 1;
                    //GetComponentInParent<MatchGame>().Finished(false);
                    NoObj.SetActive(true);
                    GetComponentInParent<MatchGame>().WrongAnswer();
                }
                return;
            }
        }
      
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            offset = Mathf.Lerp(offset, HeightOffset, 5 * Time.deltaTime);
            Vector3 pos = new Vector3(hit.point.x, StartPos.y + offset, hit.point.z);
            transform.position = pos;
            /*if (hit.transform.GetComponent<MatchObj>() == this)
            {
                
            }
            else
            {
                Vector3 pos = new Vector3(transform.position.x, StartPos.y, transform.position.z);
                transform.position = pos;
            }*/
        }
        else
        {
            Vector3 pos = new Vector3(transform.position.x, StartPos.y, transform.position.z);
            transform.position = pos;
        }
           
    }
    private void OnMouseDown()
    {
        if (!finished)
        {
            SelectedCoolTimestamp = Time.time + 1;
            ResultObj.SetActive(false);
            YesObj.SetActive(false);
            NoObj.SetActive(false);
            Activated = true;
        }
    }
    public void ResetG()
    {
        ResultObj.SetActive(false);
        YesObj.SetActive(false);
        NoObj.SetActive(false);
        Activated = false;
    }
   

}
