using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDecider : MonoBehaviour
{
    [SerializeField] Vector3 straightRotation;
    [SerializeField] Vector3 curvedRotation;
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
            attachedObject.eulerAngles = curvedRotation;
        else
            attachedObject.eulerAngles = straightRotation;
            
    }
}
