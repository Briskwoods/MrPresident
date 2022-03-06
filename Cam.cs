using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public DialogMan TheDialog;
    public Transform LookAtTarget;
    Quaternion StartRot;
    public float LookSpeed = 20;
    public Transform LookHelper;
    // Start is called before the first frame update
    void Start()
    {
        StartRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (TheDialog != null)
        {
            if (LookAtTarget != null&&TheDialog.ActiveDialog!=null&&!TheDialog.Holder.activeSelf&&!TheDialog.GameOver)
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
