using System.Collections;
using UnityEngine;

public class FadeOutTrigger : MonoBehaviour
{
    public FadeOut fadeOut; // Reference to the FadeOut script
    private bool fadeOutTriggered = false; // Flag to track if fade-out has been triggered

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, GlobalSettings.maxClickDistance))
        {
            if (hit.transform == transform)
            {
                if (!fadeOutTriggered)
                {
                    Debug.Log("Cube clicked! Starting fade-out...");
                    fadeOutTriggered = true;
                    StartCoroutine(fadeOut.FadeToBlack()); // Trigger fade-out
                }
            }
        }
    }
}
