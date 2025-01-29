using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class SnapToObject : MonoBehaviour
{
    public TextMeshProUGUI attachToObject;
    public PickUpObjects player;
    public bool isObjectAttached = false;
    public bool isCurved;

    private void Awake()
    {
        attachToObject.gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (!attachToObject.gameObject.activeSelf)
        {
            attachToObject.gameObject.SetActive(true);
            if (isObjectAttached == false)
            {
                attachToObject.text = "[F]Place object";
            }
            else
            {
                attachToObject.text = "[F]Deattach object";
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("placingPoint"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (isObjectAttached)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 10, LayerMask.GetMask("pickUpObjects")) && player.pickedupObject == null)
                {
                    Debug.Log("This part works");
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        Debug.Log("pickedUpObject was not null!");
                        player.isObjectPickedUp = true;
                        this.GetComponent<Rigidbody>().isKinematic = false;
                        this.transform.position = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y - 1, Camera.main.transform.localPosition.z + 2);
                        player.pickedupObject = this.gameObject;
                        player.pickedupObject.transform.SetParent(Camera.main.transform);
                        player.holdingObject();
                        isObjectAttached = false;
                    }
                }
            }
            else
            {
                player.isObjectPickedUp = false;
                player.releaseObject.gameObject.SetActive(false);
                this.GetComponent<Rigidbody>().isKinematic = true;
                player.pickedupObject.transform.SetParent(null);
                player.pickedupObject = null;
                this.transform.position = other.transform.position;
                other.gameObject.GetComponent<CableDecider>().CheckIfCurved(this.transform, isCurved);
                isObjectAttached = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        attachToObject.gameObject.SetActive(false);
    }
}
