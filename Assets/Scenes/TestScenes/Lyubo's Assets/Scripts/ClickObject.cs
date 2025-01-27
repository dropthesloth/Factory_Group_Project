using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour
{
    public string targetTag = "Interactables";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetClickedObject(out RaycastHit hit))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    print("clicked/touched!");
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("Mouse is off!");
        }
    }

    bool GetClickedObject(out RaycastHit hit)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            Debug.Log(ray.direction * 10);
            if (!isPointerOverUIObject())
            {
                return true;
            }
        }
        hit = default;
        return false;
    }

    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
