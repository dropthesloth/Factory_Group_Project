using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckObjectsCorrectPlace : MonoBehaviour
{
    public GameObject[] PlacingPlaces;
    public GameObject[] correctOrderObjects;
    public SnapToObject[] snapToObject;
    private SnapToObject currentObject;
    private SnapToObject[] allPlacedObjects;
    private float positionTolerance = 0.1f; 

    private void Start()
    {
        allPlacedObjects = new SnapToObject[PlacingPlaces.Length];
    }
    void Update()
    {
        if (isObjectAttached() == true)
        {
            addObjectToArray();
        }
        if (isArrayTheSame() == true) 
        {
            Debug.Log("Both arrays are the same!");
            //place the reward for getting it correct
        }
    }

    public bool isArrayTheSame()
    {
        for (var i = 0; i < correctOrderObjects.Length; i++)
        {
            if (allPlacedObjects[i]?.gameObject != correctOrderObjects[i])
            {
                return false;
            }
        }
        return true;
    }

    public void addObjectToArray()
    {
        for (var i = 0; i < PlacingPlaces.Length; i++)
        {
            if (Vector3.Distance(PlacingPlaces[i].transform.position, currentObject.transform.position) <= positionTolerance) 
            {
                Debug.Log("Both positions are the same!");
                for (var j = 0; j < allPlacedObjects.Length; j++)
                {

                    if (allPlacedObjects[j] == currentObject)
                    {
                        Debug.Log("Deleting duplicate!");
                        allPlacedObjects[j] = null;
                        break;  
                    }

                }
                Debug.Log("Object is added!");
                allPlacedObjects[i] = currentObject;
            }
        }
    }

    private bool isObjectAttached()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out RaycastHit hit, LayerMask.GetMask("pickUpObject")))
        {
            for (int i = 0; i < snapToObject.Length; i++)
            {
                if (hit.transform.position == snapToObject[i].transform.position)
                {
                    currentObject = snapToObject[i];
                    return currentObject.isObjectAttached;
                }
            }
        }
        return false;
    }
}
