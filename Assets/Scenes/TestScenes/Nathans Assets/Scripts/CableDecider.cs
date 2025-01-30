using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDecider : MonoBehaviour
{
    [SerializeField] Transform straightPlacement;
    [SerializeField] Transform curvedPlacement;
    [SerializeField] CheckObjectsCorrectPlace checkObjectsRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckIfCurved(Transform attachedObject, bool isCurved)
    {
        if (isCurved)
        {
            attachedObject.eulerAngles = curvedPlacement.eulerAngles;
            attachedObject.localScale = curvedPlacement.localScale;
        }
        else
        { 
            attachedObject.eulerAngles = straightPlacement.eulerAngles;
            attachedObject.localScale = straightPlacement.localScale;
        }
        checkObjectsRef.addObjectToArray(attachedObject.gameObject.GetComponent<SnapToObject>());     
    }
}
