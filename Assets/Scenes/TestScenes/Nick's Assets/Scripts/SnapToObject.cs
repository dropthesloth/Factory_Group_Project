using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class SnapToObject : MonoBehaviour
{
    public PickUpObjects player;
    public bool isObjectAttached = false;
    public bool canPlace;
    public bool isCurved;
    [SerializeField] CheckObjectsCorrectPlace checkObjectsRef;
    public bool lookingAtPlayer;
    private void Awake()
    {
        canPlace = false;
        lookingAtPlayer = false;
    }

    private void OnTriggerStay(Collider other)
    {

        if (/*Input.GetKeyDown(KeyCode.F) &&*/ other.CompareTag("placingPoint"))
        {
            Debug.Log("Do you work?");
            if (player.pickedupObject == this.gameObject || isObjectAttached)
                canPlace = true;
            else
                canPlace = false;
            if (Input.GetKeyDown(KeyCode.F))
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
                            player.pickedupObject.transform.localScale *= 0.125f;
                            player.pickedupObject.transform.localEulerAngles = new Vector3(-45, 0, 90);
                            player.pickedupObject.transform.SetParent(Camera.main.transform);
                            player.holdingObject();
                            player.releaseObjectText.gameObject.SetActive(true);
                            isObjectAttached = false;
                            checkObjectsRef.removeObjectFromArray(this.gameObject);
                        }
                    }
                }
                else if (player.pickedupObject == this.gameObject)
                {
                    player.isObjectPickedUp = false;
                    player.releaseObjectText.gameObject.SetActive(false);
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    player.pickedupObject.transform.SetParent(null);
                    player.pickedupObject = null;
                    this.transform.position = other.transform.position;
                    other.gameObject.GetComponent<CableDecider>().CheckIfCurved(this.transform, isCurved);
                    isObjectAttached = true;
                }
            }
        }
        /*else if (player.pickedupObject != this.gameObject)
            canPlace = false;*/
    }

    private void OnTriggerExit(Collider other)
    {
        canPlace = false;
    }
}
