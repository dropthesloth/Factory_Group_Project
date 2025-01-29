using UnityEngine;
using UnityEngine.UI;

public class GlowOnMouseover : MonoBehaviour
{
    private Outline outlineComp;

    private void LateUpdate()
    {
        outlineComp = GetComponent<Outline>();
    }

    private void OnMouseOver()
    {
        outlineComp.enabled = true;
        // Debug.Log("lalala"); 

    }

    private void OnMouseExit()
    {
        outlineComp.enabled = false;
    }
}
