using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoubleDoorOpener : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    bool openDoor;
    [SerializeField]Vector3 endPositionDoor1;
    [SerializeField] Vector3 endPositionDoor2;
    public TextMeshProUGUI doorPanelText;
    // Start is called before the first frame update
    void Start()
    {
        /*endPosition = door.transform.position;
        endPosition.z = door.transform.position.z - 15;*/
        openDoor = false;
        if (doorPanelText != null)
            doorPanelText.text = "CLOSED";
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            door1.transform.position = Vector3.MoveTowards(door1.transform.position, endPositionDoor1, 0.1f);
            door2.transform.position = Vector3.MoveTowards(door2.transform.position, endPositionDoor2, 0.1f);
        }
    }
    public void OpenDoor()
    {
        openDoor = true;
        if (doorPanelText != null)
        {
            doorPanelText.text = "OPEN";
            doorPanelText.color = Color.green;
        }

    }
}
