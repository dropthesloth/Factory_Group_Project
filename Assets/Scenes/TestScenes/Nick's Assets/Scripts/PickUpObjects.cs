using TMPro;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PickUpObjects : MonoBehaviour
{
    public TextMeshProUGUI pickUpObject;
    public TextMeshProUGUI releaseObject;
    public PlayerMovement player;
    public float pickUpRange;
    public string targetTag = "pickUpObject";
    public bool isObjectPickedUp = false;
    public GameObject pickedupObject;
    private SnapToObject snapToObject;
    private RaycastHit objectHit;

    void Update()
    {
        pickUp();
        holdingObject();
    }

    public void pickUp()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out objectHit, pickUpRange, LayerMask.GetMask("pickUpObject")))
        {
            if (isObjectPickedUp == false)
            {
                //pickUpObject.gameObject.SetActive(true);
            } else
            {
                //pickUpObject.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Is the object picked up or not
                if (isObjectPickedUp)
                {
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        //releaseObject.gameObject.SetActive(false);
                        isObjectPickedUp = false;
                        objectHit.rigidbody.useGravity = true;
                        pickedupObject.transform.SetParent(null);
                        pickedupObject = null;
                    }
                }
                else
                {
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        snapToObject = objectHit.collider.GetComponent<SnapToObject>();
                        if (!snapToObject.isObjectAttached) 
                        {
                            //pickUpObject.gameObject.SetActive(false);
                            isObjectPickedUp = true;
                            objectHit.rigidbody.useGravity = false;
                            pickedupObject = objectHit.collider.gameObject;
                            pickedupObject.transform.SetParent(Camera.main.transform);
                        }
                
                    }
                }
            }
        } else
        {
            //pickUpObject.gameObject.SetActive(false);
        }
    }
    public void holdingObject()
    {
        if (pickedupObject != null)
        {
            pickedupObject.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y - 0.5f, Camera.main.transform.localPosition.z + 2);
            pickedupObject.transform.eulerAngles = Vector3.zero;
            pickedupObject.transform.localScale = Vector3.one;
        }
    }

    public RaycastHit GetObjecHit()
    {
        return objectHit;
    }
}
