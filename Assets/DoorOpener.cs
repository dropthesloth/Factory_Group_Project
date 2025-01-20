using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoorOpener : MonoBehaviour
{
    public GameObject door;
    bool openDoor;
    Vector3 endPosition;
    public TextMeshProUGUI doorPanelText;
    // Start is called before the first frame update
    void Start()
    {
        endPosition = door.transform.position;
        endPosition.z = door.transform.position.z - 15;
        openDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, endPosition, 0.1f);
        }
    }
    public void OpenDoor()
    {
        openDoor = true;
        doorPanelText.text = "OPEN";
        doorPanelText.color = Color.green;
    }
}
