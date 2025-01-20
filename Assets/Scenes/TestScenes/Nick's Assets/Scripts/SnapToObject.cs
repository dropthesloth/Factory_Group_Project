using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnapToObject : MonoBehaviour
{
    public PickUpObjects player;
    private Vector3 originalObjectLocation;
    private bool isObjectAttached = false;
    private void OnTriggerStay(Collider other)
    {
        
        if (Input.GetKeyDown(KeyCode.F) && isObjectAttached == false)
        {
            originalObjectLocation = this.transform.position;
            player.isObjectPickedUp = false;
            this.gameObject.transform.position = other.transform.position;
            isObjectAttached = true;
            
        }else if (Input.GetKeyDown(KeyCode.F) && isObjectAttached == true)
        {
            player.isObjectPickedUp = true;
            this.gameObject.transform.position = originalObjectLocation;
            isObjectAttached = false;
        }
    }
}
