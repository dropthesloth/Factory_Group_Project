using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOutlineToInteractableObjects : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameObject[] interactableObjects = GameObject.FindGameObjectsWithTag("Interactables");
        foreach (GameObject interactable in interactableObjects)
        {
            if (interactable.GetComponent<Outline>() == null)
            {
                interactable.AddComponent<Outline>();
                interactable.GetComponent<Outline>().enabled = false;
                interactable.GetComponent<Outline>().OutlineColor = Color.yellow;
                interactable.GetComponent<Outline>().OutlineWidth = 5;
            }
            GlowOnMouseover glowComponent = interactable.GetComponent<GlowOnMouseover>();
            if (glowComponent == null)
            {
                glowComponent = interactable.AddComponent<GlowOnMouseover>();
                glowComponent.enabled = false;
            }
            if (interactable.GetComponent<CapsuleCollider>() == null)
            {
                interactable.AddComponent<CapsuleCollider>();
            }
            if (interactable.GetComponent<CapsuleCollider>().isTrigger == false)
            {
                interactable.GetComponent<CapsuleCollider>().isTrigger = true;
            }
        }
    }
}
