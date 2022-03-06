using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartboardController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag == "Dart")
        {
            case true:
                collision.collider.gameObject.transform.parent.localScale *=3;
                collision.collider.gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
                break;
            case false:
                break;
        }
    }
}
