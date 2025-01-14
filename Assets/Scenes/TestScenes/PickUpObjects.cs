using UnityEngine;
using UnityEngine.UIElements;

public class PickUpObjects : MonoBehaviour
{
    public GameObject player;
    public float pickUpRange;
    public int outerPlayerPoint;

    private Vector3 playerPosition;
    private bool isObjectPickedUp = false;
    private RaycastHit ObjectHit;
    private Vector3 objectoriginalPosition;
    

    void Start()
    {
        playerPosition = player.transform.position;
    }
    void Update()
    {
        pickUp();
        holdingObject();
    }

    void pickUp()
    {
        //Picking up the object
        if (Input.GetKeyDown(KeyCode.E) && !isObjectPickedUp)
        {
            for (int i = 2; i <=outerPlayerPoint; i+=2)
            {
                Physics.Raycast(new Vector3(playerPosition.x + i, playerPosition.y, playerPosition.z), Vector3.forward, out ObjectHit, pickUpRange);
                Physics.Raycast(new Vector3(playerPosition.x, playerPosition.y + i, playerPosition.z), Vector3.forward, out ObjectHit, pickUpRange);
                Physics.Raycast(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + i), Vector3.forward, out ObjectHit, pickUpRange);
            }
            Physics.Raycast(playerPosition, Vector3.forward, out ObjectHit, pickUpRange);


            if (ObjectHit.collider != null && ObjectHit.collider.CompareTag("pickUpObject"))
            {
                isObjectPickedUp = true;
                Debug.Log("I hit a pickUpObject!" +
                    " This is the gameObject: " + ObjectHit.transform.gameObject +
                    " this is the distance: " + ObjectHit.distance +
                    " isObjectPickedUp: " + isObjectPickedUp);
                objectoriginalPosition = ObjectHit.transform.position;
            }
           
        } 
        //Releasing the object (back to original position for now)
        else if (isObjectPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            ObjectHit.transform.position = objectoriginalPosition;
            isObjectPickedUp = false;
            Debug.Log("isObjectPickedUp: " + isObjectPickedUp);
        }
    }
    void holdingObject()
    {
        if (isObjectPickedUp == true)
        {
            //Set the position of where the object is.
            ObjectHit.transform.position = new Vector3 (objectoriginalPosition.x,objectoriginalPosition.y,objectoriginalPosition.z+1);
        }
    }
}
