using UnityEngine;
using UnityEngine.UIElements;

public class PickUpObjects : MonoBehaviour
{
    public GameObject player;
    public float pickUpRange;
    public int outerPlayerPoint;


    private RaycastHit objectHit;
    public Vector3 playerPosition;
    public bool isObjectPickedUp = false;
    

    void Start()
    {
        playerPosition = player.transform.localPosition;
    }
    void Update()
    {
        //Raycast from middle of the player
        Physics.Raycast(playerPosition, Vector3.forward, out objectHit, pickUpRange, 1 << LayerMask.NameToLayer("pickUp"));
        pickUp();
        holdingObject();
        playerPosition = player.transform.position;


    }

    public void pickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Is the object picked up or not
            if (isObjectPickedUp)
            {
                if (objectHit.collider != null && objectHit.collider.CompareTag("pickUpObject"))
                {
                    isObjectPickedUp = false;
                    objectHit.rigidbody.useGravity = true;
                }
            }
            else if (!isObjectPickedUp)
            {
                if (objectHit.collider != null && objectHit.collider.CompareTag("pickUpObject"))
                {
                    isObjectPickedUp = true;
                    objectHit.rigidbody.useGravity = false;
                }
            }
        }
    }
    public void holdingObject()
    {
        if (isObjectPickedUp == true && objectHit.collider != null && objectHit.collider.CompareTag("pickUpObject"))
        {
            //Set the position of where the object is.
            objectHit.transform.position = new Vector3 (playerPosition.x,playerPosition.y,playerPosition.z + 2);
        }
    }
}
