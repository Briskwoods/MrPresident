using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandController : MonoBehaviour
{
    // Raycast Control Variable
    [SerializeField] private Camera m_mainCamera;

    // Hand Control Variables
    [SerializeField] private GameObject m_rightHand;

    [Range (1, 100)]
    [SerializeField] private int m_handSpeed = 75;

    private Vector3 m_originalPosition;


    public PictureCheckForInput pictureCheckForInput_;
    public PictureController pictureController_;

    void Start()
    {
        m_originalPosition = transform.position;
        m_rightHand.transform.position = m_originalPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
       // Hand Follows Mouse Movement
       Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
       switch (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            case true:
                m_rightHand.transform.position = Vector3.MoveTowards(m_rightHand.transform.position, raycastHit.point, m_handSpeed);

                switch(raycastHit.collider.tag == "ZoneBlock")
                {
                    case true:
                        switch (pictureCheckForInput_.m_isDragging)
                        {
                            case true:
                                if(!raycastHit.collider.gameObject.GetComponent<ZoneController>().isTaken)
                                {
                                    raycastHit.collider.gameObject.GetComponent<ZoneController>().isTaken = true;
                                }
                                try
                                {
                                    pictureController_.CheckIfDone();
                                }
                                catch(Exception e) { }
                                break;
                            case false: break;
                        }
                        break;
                    case false: break;
                }
                break;
            case false: break;
        }
    }
}
