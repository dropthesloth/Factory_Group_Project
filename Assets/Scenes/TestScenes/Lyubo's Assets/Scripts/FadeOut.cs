using System.Collections;
using UnityEngine;

public class FadeOutTrigger : MonoBehaviour
{
    public FadeOut fadeOut; // Reference to the FadeOut script
    private bool fadeOutTriggered = false; // Flag to track if fade-out has been triggered
    bool canFinishGame;
    private void Start()
    {
        canFinishGame = false;
    }
    public void UnlockElevator()
    {
        canFinishGame = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (!fadeOutTriggered && canFinishGame)
        {
            Debug.Log("Cube clicked! Starting fade-out...");
            fadeOutTriggered = true;
            StartCoroutine(fadeOut.FadeToBlack()); // Trigger fade-out
        }
    }
}
