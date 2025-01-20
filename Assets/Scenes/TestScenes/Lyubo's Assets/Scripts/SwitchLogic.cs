using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchLogic : MonoBehaviour
{
    public List<GameObject> switches; // List of switch GameObjects
    public List<int> correctPattern; // List of correct pattern indices
    public UnityEvent finishEvent;
    private int currentStep = 0;

    void Start()
    {
        ResetSwitches();
    }

    public void OnSwitchClicked(int switchIndex)
{
    // Check if the clicked switch is the first in the correct pattern
    if (switchIndex == correctPattern[0])
    {
        // Reset all switches when starting a new sequence
        ResetSwitches();

        // Turn on the first switch in the pattern
        switches[switchIndex].GetComponent<Renderer>().material.color = Color.green;

        // Set the current step to the first step
        currentStep = 1;
    }
    else if (currentStep > 0 && switchIndex == correctPattern[currentStep])
    {
        // Continue the sequence if the switch is the correct next one
        switches[switchIndex].GetComponent<Renderer>().material.color = Color.green;
        currentStep++;

        if (currentStep >= correctPattern.Count)
        {
            Debug.Log("Correct pattern entered!");
                // Add additional logic here for successful completion
                finishEvent.Invoke();
            
        }
    }
    else
    {
        // Reset the sequence and turn on the clicked switch
        ResetSwitches();
        switches[switchIndex].GetComponent<Renderer>().material.color = Color.green;

        // Reset step count
        currentStep = 0;
    }
}


    private void ResetSwitches()
    {
        foreach (GameObject switchObj in switches)
        {
            switchObj.GetComponent<Renderer>().material.color = Color.red; // Turn off the switch
        }
        currentStep = 0;
    }
}