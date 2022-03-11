using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 InitialPosition;
    public Vector3 PlayerPos;
    public Transform PlayerCharacter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InitialPosition = Input.mousePosition;
            PlayerPos = PlayerCharacter.position;
        }
    }
}
