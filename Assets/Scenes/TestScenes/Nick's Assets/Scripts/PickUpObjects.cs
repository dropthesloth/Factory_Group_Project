using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpObjects : MonoBehaviour
{
    public GameObject pickUpObjectText;
    public GameObject releaseObjectText;
    public GameObject attachToObjectText;
    public PlayerMovement player;
    public float pickUpRange;
    public string targetTag = "pickUpObject";
    public bool isObjectPickedUp = false;
    public GameObject pickedupObject;
    private SnapToObject snapToObject;
    private RaycastHit objectHit;
    [SerializeField] Vector3 pickedUpObjectModifier;

    private void Awake()
    {
        pickUpObjectText.gameObject.SetActive(false);
        releaseObjectText.gameObject.SetActive(false);
        attachToObjectText.gameObject.SetActive(false);
    }
    void Update()
    {
        holdingObject();
        pickUp();
        
    }

    public void pickUp()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out objectHit, pickUpRange, LayerMask.GetMask("pickUpObjects")))
        {
            Debug.Log(pickUpRange);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (isObjectPickedUp == false && !pickUpObjectText.gameObject.activeSelf)
            {
                if (!objectHit.transform.GetComponent<SnapToObject>().isObjectAttached)
                {
                    pickUpObjectText.gameObject.SetActive(true);
                }
            }

            if (!attachToObjectText.gameObject.activeSelf && objectHit.transform.GetComponent<SnapToObject>().canPlace)
            {
                attachToObjectText.gameObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Is the object picked up or not
                if (!isObjectPickedUp)
                {
                    /*if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        Debug.Log("Release Object");
                        if (releaseObjectText.gameObject.activeSelf)
                            releaseObjectText.gameObject.SetActive(false);
                        isObjectPickedUp = false;
                        pickedupObject.transform.localScale *= 8f;
                        pickedupObject.transform.SetParent(null);
                        if (pickUpObjectText.transform.position.y < 2)
                        {
                            pickUpObjectText.transform.position = Vector3.up * 2;
                        }
                        pickedupObject = null;
                        objectHit.transform.eulerAngles = new Vector3(90, 0, 0);
                        objectHit.rigidbody.useGravity = true;
                        objectHit.collider.isTrigger = false;
                        

                    }
                }
                else
                {*/
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        snapToObject = objectHit.collider.GetComponent<SnapToObject>();
                        if (!snapToObject.isObjectAttached)
                        {
                            pickUpObjectText.gameObject.SetActive(false);
                            if (!releaseObjectText.gameObject.activeSelf)
                                releaseObjectText.gameObject.SetActive(true);
                            isObjectPickedUp = true;
                            objectHit.rigidbody.useGravity = false;
                            objectHit.collider.isTrigger = true;
                            pickedupObject = objectHit.collider.gameObject;
                            pickedupObject.transform.localScale *= 0.125f;
                            pickedupObject.transform.SetParent(Camera.main.transform);
                            pickedupObject.transform.localEulerAngles = new Vector3(-45, 0, 90);
                            //pickedupObject.transform.localPosition = Camera.main.transform.localPosition + pickedUpObjectModifier;
                        }

                    }
                }
            }
        }
        else
        {
            pickUpObjectText.gameObject.SetActive(false);
            attachToObjectText.gameObject.SetActive(false);
        }
        /*if (pickedupObject != null)
        {
            if (!attachToObject.gameObject.activeSelf && pickedupObject.GetComponent<SnapToObject>().canPlace)
            {

                attachToObject.gameObject.SetActive(true);
            }
            if (pickedupObject.transform.GetComponent<SnapToObject>().isObjectAttached)
            {
                attachToObject.text = "[F]Place object";
            }
        }*/
    }
    public void holdingObject()
    {
        if (pickedupObject != null && pickedupObject.CompareTag(targetTag))
        {
             if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Release Object");
                if (releaseObjectText.gameObject.activeSelf)
                    releaseObjectText.gameObject.SetActive(false);
                isObjectPickedUp = false;
                pickedupObject.transform.localScale *= 8f;
                pickedupObject.transform.SetParent(null);
                if (pickUpObjectText.transform.position.y < 2)
                {
                    pickUpObjectText.transform.position = Vector3.up * 2;
                }
                pickedupObject.transform.eulerAngles = new Vector3(90, 0, 0);
                pickedupObject.GetComponent<Rigidbody>().useGravity = true;
                pickedupObject.GetComponent<Collider>().isTrigger = false;
                pickedupObject = null;
                

            }
        }
        if (pickedupObject != null)
        {
            Debug.Log("Moving Object");
            pickedupObject.transform.localPosition = Camera.main.transform.localPosition + pickedUpObjectModifier/*new Vector3(Camera.main.transform.localPosition + pickedUpObjectModifier /*.x, Camera.main.transform.localPosition.y - 3f, Camera.main.transform.localPosition.z + 1f)*/;
            //pickedupObject.transform.localScale = Vector3.one;
        }
    }

    public RaycastHit GetObjecHit()
    {
        return objectHit;
    }
}
