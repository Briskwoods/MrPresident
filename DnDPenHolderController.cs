using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DnDPenHolderController : MonoBehaviour
{
    public Grabber Grabber_;

    public GameObject PenToEnable;

    public DragAndDropMinigameController DragAndDropMinigameController_;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Drag")
        {
            case true:
                switch (other.gameObject.GetComponent<DndObjectIdentifier>().isPen)
                {
                    case true:
                        Grabber_.m_isDragging = false;
                        other.tag = "Untagged";
                        other.gameObject.transform.DORotate(new Vector3(0f, 0f, 90f), 0.5f);
                        other.gameObject.GetComponent<DnDSelectionController>().isSelected = false;
                        other.gameObject.GetComponent<DnDSelectionController>().CheckIfSelected();
                        other.gameObject.GetComponent<DnDSelectionController>().enabled = false;
                        PenToEnable.SetActive(true);
                        other.gameObject.SetActive(false);
                        DragAndDropMinigameController_.PenPositions.Remove(this);
                        DragAndDropMinigameController_.CheckWin();
                        this.gameObject.SetActive(false);
                        break;
                    case false: break;
                }
                break;
            case false:
                break;
        }
    }
}
