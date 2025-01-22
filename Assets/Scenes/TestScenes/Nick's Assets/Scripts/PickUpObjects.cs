using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpObjects : MonoBehaviour
{
    public PlayerMovement player;
    public float pickUpRange;
    public string targetTag = "Interactables";
    public string layerMask = "ignoreSnapPlace";
    public bool isObjectPickedUp = false;

    private RaycastHit objectHit;
    void Update()
    {
        //Raycast from middle of the player
        pickUp();
        holdingObject();


    }

    public void pickUp()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out objectHit, pickUpRange, 1 >> LayerMask.GetMask()))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Is the object picked up or not
                if (isObjectPickedUp)
                {
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        isObjectPickedUp = false;
                        objectHit.rigidbody.useGravity = true;
                    }
                }
                else if (!isObjectPickedUp)
                {
                    if (objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
                    {
                        isObjectPickedUp = true;
                        objectHit.rigidbody.useGravity = false;
                    }
                }
            }
        }
    }
    public void holdingObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(isObjectPickedUp == true && objectHit.collider != null && objectHit.collider.CompareTag(targetTag))
        {
            objectHit.transform.position = ray.GetPoint(2);
        }
    }

    public RaycastHit GetObjecHit()
    {
        return objectHit;
    }
}
