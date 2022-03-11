using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public DialogMan TheDialog;
    public Transform LookAtTarget;
    Quaternion StartRot;
    Vector3 StartPos;
    public float LookSpeed = 20;
    public float MoveSpeed = 20;
    public Transform LookHelper;
    public GameObject MatchLook;
    public Transform MatchPosCam;
    // Start is called before the first frame update
    void Start()
    {
        StartRot = transform.rotation;
         StartPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (TheDialog != null&&TheDialog.ActiveDialog!=null)
        {
            if (TheDialog.ActiveDialog.IsMatchQuiz&&TheDialog.ActiveDialog.WhichSplit>=3)
            {
                transform.position =Vector3.Lerp(transform.position, MatchPosCam.position,MoveSpeed*Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, MatchPosCam.rotation, LookSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, StartPos, MoveSpeed * Time.deltaTime);
                //transform.position = StartPos;
                if (LookAtTarget != null && TheDialog.ActiveDialog != null && !TheDialog.Holder.activeSelf && !TheDialog.GameOver)
                {
                    LookHelper.LookAt(LookAtTarget);
                    transform.rotation = Quaternion.Slerp(transform.rotation, LookHelper.rotation, LookSpeed * Time.deltaTime);

                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, StartRot, LookSpeed * Time.deltaTime);
                }
            }
          
        }
    }
}
