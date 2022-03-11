using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnapToPosition : MonoBehaviour
{
    public Grabber Grabber_;

    public bool isForBook = false;
    public bool isForPhone = false;

    public DragAndDropMinigameController DragAndDropMinigameController_;


    public float bookRotationX = 0f;
    public float bookRotationY = 0f;
    public float bookRotationZ = 0f;

    public Transform selfGoal;

    public GameObject expectedObject;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "Drag")
        {
            case true:
                switch (other.gameObject.GetComponent<DndObjectIdentifier>().isBook)
                {
                    case true:

                        switch (isForBook)
                        {
                            case true:

                                switch(other.gameObject == expectedObject)
                                {
                                    case true:
                                        Grabber_.m_isDragging = false;
                                        other.tag = "Untagged";
                                        other.gameObject.transform.DORotate(new Vector3(bookRotationX, bookRotationY, bookRotationZ), 0.2f);
                                        other.gameObject.transform.DOMove(selfGoal.position, 1f);
                                        other.gameObject.GetComponent<DnDSelectionController>().isSelected = false;
                                        other.gameObject.GetComponent<DnDSelectionController>().CheckIfSelected();
                                        other.gameObject.GetComponent<DnDSelectionController>().enabled = false;
                                        DragAndDropMinigameController_.Positions.Remove(this);
                                        DragAndDropMinigameController_.CheckWin();

                                        //this.gameObject.SetActive(false);
                                        break;
                                    case false:
                                        break;
                                }
                                break;
                            case false: break;
                        }
                        break;
                    case false:
                        break;
                }

                switch (other.gameObject.GetComponent<DndObjectIdentifier>().isPhone)
                {
                    case true:

                        switch (isForPhone)
                        {
                            case true:
                                switch (other.gameObject == expectedObject)
                                {
                                    case true:
                                        Grabber_.m_isDragging = false;
                                        other.tag = "Untagged";
                                        other.gameObject.transform.DORotate(new Vector3(bookRotationX, bookRotationY, bookRotationZ), 0.2f);
                                        other.gameObject.transform.DOMove(selfGoal.position, 1f);
                                        other.gameObject.GetComponent<DnDSelectionController>().isSelected = false;
                                        other.gameObject.GetComponent<DnDSelectionController>().CheckIfSelected();
                                        other.gameObject.GetComponent<DnDSelectionController>().enabled = false;
                                        DragAndDropMinigameController_.Positions.Remove(this);
                                        DragAndDropMinigameController_.CheckWin();

                                        //this.gameObject.SetActive(false);
                                        break;
                                    case false:
                                        break;
                                }
                                break;
                            case false: break;
                        }
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
