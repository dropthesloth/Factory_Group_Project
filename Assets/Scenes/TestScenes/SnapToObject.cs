using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnapToObject : MonoBehaviour
{
    public PickUpObjects pickUpObjects;
    private Vector3 originalObjectLocation;
    private bool isObjectAttached = false;
    private void OnTriggerStay(Collider other)
    {
        originalObjectLocation = this.transform.position;
        if (Input.GetKeyDown(KeyCode.F) && isObjectAttached == false)
        {
            pickUpObjects.isObjectPickedUp = false;
            this.gameObject.transform.position = other.transform.position;
            isObjectAttached = true;
            
        }else if (Input.GetKeyDown(KeyCode.F) && isObjectAttached == true)
        {
            pickUpObjects.isObjectPickedUp = true;
            this.gameObject.transform.position = originalObjectLocation;
            isObjectAttached = false;
        }
    }
}
