using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMinigameCameraController : MonoBehaviour
{
    public GameObject m_player;
    public GameObject m_mainCamera;
    public float m_xPos = 0f;
    public float m_yPos;
    public float m_zPos;
    public CameraShakeScript m_shakeScript;
    public float CameraMaxXDirection;
    public float Percent;
    float MaxPlayer_X;



    public void Start()
    {
        MaxPlayer_X = m_player.GetComponent<PlayerMovement>().PlatformWidth;;

    }

    public void LateUpdate()
    {
        switch (m_player != null)
        {
            case true:
                var playerpos = m_player.transform.position;
                playerpos.x = m_xPos;

                Percent = (m_player.transform.position.x / MaxPlayer_X) * CameraMaxXDirection;

                m_mainCamera.transform.position = playerpos + new Vector3(Percent, m_yPos, -m_zPos);

                break;
            case false:
                break;
        }
    }
}
