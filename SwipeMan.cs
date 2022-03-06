using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMan : MonoBehaviour
{
    float DragTimestamp;
    Vector3 StartPos;
    public float Speed = 5;
    float AnsweredTimestamp;
    int Which;
    public GameObject ResultHolder;
    public GameObject Yes;
    public GameObject No;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (AnsweredTimestamp > Time.time)
        {
            if (Which == 1)
            {
                transform.Translate(Vector2.right * Speed * 200 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -Speed * 200 * Time.deltaTime);
            }
        }
        else if (Time.time > DragTimestamp)
        {

            ResultHolder.SetActive(false);
            if (Which != 0)
            {
                if (Which == 1)
                {
                    GetComponentInParent<DialogMan>().AnswerSwipe(0);

                }
                else
                {
                    GetComponentInParent<DialogMan>().AnswerSwipe(1);

                }
                Which = 0;
                transform.localPosition = StartPos;
            }
            transform.localPosition = Vector3.Lerp(transform.localPosition, StartPos, Speed * Time.deltaTime) ;
        }
    }

    public void MouseDrag()
    {
        if (AnsweredTimestamp>Time.time)
        {
            return;
        }
        DragTimestamp = Time.time + 0.1f;
        transform.position = Input.mousePosition;
        if (transform.position.x > (Screen.width / 2)+200)
        {
            ResultHolder.SetActive(true);
            Yes.SetActive(true);
            No.SetActive(false);
            Which = 1;
            AnsweredTimestamp = Time.time + 1;
           // transform.localPosition = StartPos;
            // Debug.Log("Right");
        }
        else if (transform.position.x < (Screen.width / 2)-200)
        {
            ResultHolder.SetActive(true);
            Yes.SetActive(false);
            No.SetActive(true);
            Which = -1;
            AnsweredTimestamp = Time.time + 1;
           // GetComponentInParent<DialogMan>().AnswerSwipe(false);
           // transform.localPosition =StartPos;

            // Debug.Log("Left");
        }
        // Debug.Log("MouseDrag");
    }
}
