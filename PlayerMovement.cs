using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private Animator m_playerAnim;

    public float m_speed;
    public float m_initialSpeed;

    public float PlatformWidth = 2.7f;
    public float MaxFingerDistance = 250f;
    
    private Vector3 InitialPosition;

    private float DistanceFromCenter;
    private float Direction;
    private float Percent;
    private float XPos;

    public bool m_isStopped = false;

    public MousePosition MousePos;

    public CharacterBehaviourManager CharacterBehaviourManager_;

    // Start is called before the first frame update
    void Start()
    {
        m_initialSpeed = m_speed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (!m_isStopped)
        {
            case true:

                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward * 10, m_speed * Time.deltaTime);
                CharacterBehaviourManager_.SetAnimation("Walking");

                if (Input.GetMouseButtonDown(0))
                {
                    InitialPosition = Input.mousePosition;
                }

                if (Input.GetMouseButton(0))
                {
                    Vector3 IP = InitialPosition;
                    Vector3 IMP = Input.mousePosition;
                    IP.y = 0f;
                    IMP.y = 0f;
                    DistanceFromCenter = Vector3.Distance(IP, IMP);
                    Direction = (IP - IMP).x;

                    if (Direction > 0 && transform.position.x > -PlatformWidth)
                    {
                        //moving to the left
                        Percent = (DistanceFromCenter / MaxFingerDistance);
                        XPos = (-PlatformWidth * Percent) + MousePos.PlayerPos.x; ;
                    }
                    else if (Direction < 0 && transform.position.x < PlatformWidth)
                    {
                        //Moving to the Right
                        Percent = (DistanceFromCenter / MaxFingerDistance);
                        XPos = (PlatformWidth * Percent) + MousePos.PlayerPos.x; ;
                    }
                    else if (Direction < 0 && transform.position.x > PlatformWidth)
                    {
                        XPos = PlatformWidth;
                    }
                    else if (Direction > 0 && transform.position.x < -PlatformWidth)
                    {
                        XPos = -PlatformWidth;
                    }
                    else
                    {
                        XPos = transform.position.x;
                    }
                    if (XPos < PlatformWidth && XPos > -PlatformWidth)
                    {
                        transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
                    }
                }

                switch (Input.GetMouseButtonUp(0))
                {
                    case true:
                        //CodeManager.Instance.ThrowController_.Throw();
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }        
    }
}
