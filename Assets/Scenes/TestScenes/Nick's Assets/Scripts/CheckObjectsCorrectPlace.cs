using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CheckObjectsCorrectPlace : MonoBehaviour
{
    public GameObject[] PlacingPlaces;
    public GameObject[] correctOrderObjects;
    public SnapToObject[] snapToObject;
    [SerializeField] private SnapToObject currentObject;
    public GameObject[] allPlacedObjects;
    private float positionTolerance = 0.2f;
    public UnityEvent finishEvent;

    private void Start()
    {
        var len = PlacingPlaces.Length;
        allPlacedObjects = new GameObject[len];
        //allPlacedObjects[0] = PlacingPlaces[0];
        //Debug.Log("Does this one work though?" + allPlacedObjects[0]);
    }

    void Update()
    {
        /*if (isObjectAttached() == true)
        {
            addObjectToArray();
        }*/
        
        if (isArrayTheSame() == true)
        {
            Debug.Log("Both arrays are the same!");
            finishEvent.Invoke();
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

    public void addObjectToArray(SnapToObject currentObject)
    {
        //bool doNotRemoveObjects = false;
        Debug.Log("AddObject");
        for (var i = 0; i < PlacingPlaces.Length; i++)
        { 
            if (Vector3.Distance(PlacingPlaces[i].transform.position, currentObject.transform.position) <= positionTolerance)
            {
                /*for (var j = 0; j < allPlacedObjects.Length; j++)
                {

                    /*if (allPlacedObjects[j] == currentObject)
                    {
                        Debug.Log("Removing duplicate!");
                        allPlacedObjects[j] = null;
                        break;
                    }

                }*/
                Debug.Log("Object added to the list!");
                Debug.Log(currentObject.gameObject);
                Debug.Log(i);
                Debug.Log($"Does this one work though? {allPlacedObjects} {allPlacedObjects.Length}");
                allPlacedObjects[i] = currentObject.gameObject;
                
                //doNotRemoveObjects = true;
            }
            /*else
            {
                if (i == PlacingPlaces.Length - 1 && !doNotRemoveObjects)
                    removeObjectFromArray();
            }*/
        }
    }

    public void removeObjectFromArray(GameObject objectToRemove)
    {
        for (var j = 0; j < allPlacedObjects.Length; j++)
        {
            if (allPlacedObjects[j] == objectToRemove)
            {
                Debug.Log("Object removed!");
                allPlacedObjects[j] = null;
            }
        }
        /*for (var i = 0; i < correctOrderObjects.Length; i++)
        {
            for (var j = 0; j < allPlacedObjects.Length; j++)
            {
                if (allPlacedObjects[j] != correctOrderObjects[i])
                {
                    Debug.Log("Object removed!");
                    allPlacedObjects[j] = null;
                }
            }
        }*/
    }

    /*private bool isObjectAttached()
    {
        Debug.Log("isObjectAttached?");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out RaycastHit hit, LayerMask.GetMask("pickUpObjects")))
        {
            Debug.Log("Should object deattach?");
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
    }*/
}
