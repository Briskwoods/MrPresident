using UnityEngine;

public class Grabber : MonoBehaviour {

    public GameObject selectedObject;

    public bool m_isDragging;


    private void Update() {

        #region PC Controls
        //PC Controls Test Code, uncoomment if you wish to Test with a mouse instead of Unity Remote 5

        switch (Input.GetMouseButtonDown(0))
        {
            case true:
                m_isDragging = true;
                break;
            case false:
                break;
        }

        switch (Input.GetMouseButtonUp(0))
        {
            case true:
                m_isDragging = false;
                break;
            case false:
                break;
        }
        #endregion

        
        switch (m_isDragging)
        {
            case true:
                switch (selectedObject == null)
                {
                    case true:
                        RaycastHit hit = CastRay();

                        switch (hit.collider != null)
                        {
                            case true:
                                switch (!hit.collider.CompareTag("Drag"))
                                {
                                    case true: return;
                                    case false: break;
                                }
                                selectedObject = hit.collider.gameObject;
                                selectedObject.GetComponent<DnDSelectionController>().isSelected = true;
                                selectedObject.GetComponent<DnDSelectionController>().CheckIfSelected();
                                Cursor.visible = false;
                                break;
                            case false:
                                break;

                        }
                        break;
                    case false:
                        
                        break;
                }
                break;
            case false:

                switch (selectedObject != null)
                {
                    case true:
                        selectedObject.GetComponent<DnDSelectionController>().isSelected = false;
                        selectedObject.GetComponent<DnDSelectionController>().CheckIfSelected();
                        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                        selectedObject.transform.position = new Vector3(worldPosition.x, -0.35f, worldPosition.z);

                        selectedObject = null;
                        Cursor.visible = true; 
                        break;
                    case false: break;
                }
                break;
        }

        switch(selectedObject != null)
        {
            case true:
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, -0.25f, worldPosition.z);
                //    switch (Input.GetMouseButtonDown(1))
                //{
                //    case true:
                //        selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                //            selectedObject.transform.rotation.eulerAngles.x,
                //            selectedObject.transform.rotation.eulerAngles.y + 90f,
                //            selectedObject.transform.rotation.eulerAngles.z));
                //        break;
                //    case false: break;
                //}
                break;
            case false: break;
        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
