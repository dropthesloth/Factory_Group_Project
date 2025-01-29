using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DoorUnlocker : MonoBehaviour
{

    public GameObject door;
    bool doorUnlocked;
    bool doorOpened;
    public TextMeshProUGUI doorText;
    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
        doorUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpened && door.transform.rotation.eulerAngles.y != 90f)
        {
            door.transform.eulerAngles = Vector3.MoveTowards(door.transform.eulerAngles, new Vector3(0, 90, 0), 0.2f);
        }
    }
    private void OnMouseDown()
    {
        if (doorUnlocked)
            doorOpened = true;
    }
    public void UnlockDoor()
    {
        doorUnlocked = true;

    }
}
