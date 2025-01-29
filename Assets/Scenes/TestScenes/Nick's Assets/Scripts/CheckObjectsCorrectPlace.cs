using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CheckObjectsCorrectPlace : MonoBehaviour
{
    public GameObject[] PlacingPlaces;
    public GameObject[] correctOrderObjects;
    public SnapToObject[] snapToObject;
    private SnapToObject currentObject;
    public GameObject[] allPlacedObjects;
    private float positionTolerance = 0.2f; 

    private void Start()
    {
        allPlacedObjects = new GameObject[PlacingPlaces.Length];
    }
    void Update()
    {
        removeObjectFromArray();
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
        for (var i = correctOrderObjects.Length - 1; i >= 0; i--)
        {
            if (allPlacedObjects == null || allPlacedObjects[i]?.gameObject != correctOrderObjects[i])
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
                for (var j = 0; j < allPlacedObjects.Length; j++)
                {

                    if (allPlacedObjects[j] == currentObject)
                    {
                        Debug.Log("Removing duplicate!");
                        allPlacedObjects[j] = null;
                        break;  
                    }

                }
                Debug.Log("Object added to the list!");
                allPlacedObjects[i] = currentObject.gameObject;
            }
        }
    }

    public void removeObjectFromArray()
    {
        for (var i = 0; i < PlacingPlaces.Length; i++)
        {
                for (var j = 0; j < allPlacedObjects.Length; j++)
                {
                    if (allPlacedObjects[j] != PlacingPlaces[i])
                    {
                        Debug.Log("Object removed!");
                        allPlacedObjects[j] = null;
                    }
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
