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
    public TextMeshProUGUI attachToObject;
    public PlayerMovement player;
    public float pickUpRange;
    public string targetTag = "pickUpObject";
    public bool isObjectPickedUp = false;
    public GameObject pickedupObject;
    private SnapToObject snapToObject;
    private RaycastHit objectHit;

    private void Awake()
    {
        pickUpObject.gameObject.SetActive(false);
        releaseObject.gameObject.SetActive(false);
        attachToObject.gameObject.SetActive(false);
    }
    void Update()
    {
        pickUp();
        holdingObject();
    }

    public void pickUp()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out objectHit, pickUpRange, LayerMask.GetMask("pickUpObjects")))
        {
            if (isObjectPickedUp == false && !pickUpObject.gameObject.activeSelf)
            {
                if (!objectHit.transform.GetComponent<SnapToObject>().isObjectAttached)
                {
                    pickUpObject.gameObject.SetActive(true);
                }
            }

            if (!attachToObject.gameObject.activeSelf && objectHit.transform.GetComponent<SnapToObject>().canPlace)
            {
                attachToObject.gameObject.SetActive(true);
                if (!objectHit.transform.GetComponent<SnapToObject>().isObjectAttached)
                {
                    attachToObject.text = "[F]Place object";
                }
                else
                {
                    attachToObject.text = "[F]Deattach object";
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Is the object picked up or not
                if (isObjectPickedUp)
                {
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        if (releaseObject.gameObject.activeSelf)
                            releaseObject.gameObject.SetActive(false);
                        isObjectPickedUp = false;
                        pickedupObject.transform.localScale *= 8f;
                        pickedupObject.transform.SetParent(null);
                        if (pickUpObject.transform.position.y < 2)
                        {
                            pickUpObject.transform.position = Vector3.up * 2;
                        }
                        pickedupObject = null;
                        objectHit.transform.eulerAngles = new Vector3(90, 0, 0);
                        objectHit.rigidbody.useGravity = true;
                        objectHit.collider.isTrigger = false;
                        

                    }
                }
                else
                {
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        snapToObject = objectHit.collider.GetComponent<SnapToObject>();
                        if (!snapToObject.isObjectAttached)
                        {
                            pickUpObject.gameObject.SetActive(false);
                            if (!releaseObject.gameObject.activeSelf)
                                releaseObject.gameObject.SetActive(true);
                            isObjectPickedUp = true;
                            objectHit.rigidbody.useGravity = false;
                            objectHit.collider.isTrigger = true;
                            pickedupObject = objectHit.collider.gameObject;
                            pickedupObject.transform.localScale *= 0.125f;
                            pickedupObject.transform.SetParent(Camera.main.transform);
                        }

                    }
                }
            }
        }
        else
        {
            pickUpObject.gameObject.SetActive(false);
            attachToObject.gameObject.SetActive(false);
        }
    }
    public void holdingObject()
    {
        if (pickedupObject != null)
        {
            Debug.Log("Moving Object");
            pickedupObject.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y - 3f, Camera.main.transform.localPosition.z + 1f);
            pickedupObject.transform.eulerAngles = Vector3.right;
            //pickedupObject.transform.localScale = Vector3.one;
        }
    }

    public RaycastHit GetObjecHit()
    {
        return objectHit;
    }
}
