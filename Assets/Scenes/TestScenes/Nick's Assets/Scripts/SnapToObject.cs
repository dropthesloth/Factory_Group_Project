using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnapToObject : MonoBehaviour
{
    public PickUpObjects player;
    private Vector3 originalObjectLocation;
    public bool isObjectAttached = false;
    private void OnTriggerStay(Collider other)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.F) && isObjectAttached == false)
        {
            originalObjectLocation = this.transform.position;
            player.isObjectPickedUp = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.transform.position = other.transform.position;
            isObjectAttached = true;
            
        }else if (Input.GetKeyDown(KeyCode.F) && isObjectAttached == true && Physics.Raycast(ray.origin,ray.direction * 10))
        {
            player.isObjectPickedUp = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.transform.position = originalObjectLocation;
            isObjectAttached = false;
        }
    }
}
