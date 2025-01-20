using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwitchDependency
{
    public List<int> dependentSwitchIndices;
}

public class SwitchLogic : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> switches; // List of switch GameObjects

    [SerializeField]
    private List<SwitchDependency> switchDependencies; // List of dependencies for each switch

    void Start()
    {
        ResetSwitches();
    }

    public void OnSwitchClicked(int switchIndex)
    {
        // Toggle the main switch
        bool newState = switches[switchIndex].GetComponent<Renderer>().material.color != Color.green;
        ToggleSwitch(switchIndex, newState);

        if (AreAllSwitchesOn())
        {
            Debug.Log("All switches are on! Puzzle completed!");
            // Add additional logic here for successful completion
        }
    }

    private void ToggleSwitch(int switchIndex, bool state)
    {
        switches[switchIndex].GetComponent<Renderer>().material.color = state ? Color.green : Color.red;

        foreach (int dependentSwitchIndex in switchDependencies[switchIndex].dependentSwitchIndices)
        {
            switches[dependentSwitchIndex].GetComponent<Renderer>().material.color = state ? Color.green : Color.red;
        }
    }

    private bool AreAllSwitchesOn()
    {
        foreach (GameObject switchObj in switches)
        {
            if (switchObj.GetComponent<Renderer>().material.color != Color.green)
            {
                return false;
            }
        }
        return true;
    }

    private void ResetSwitches()
    {
        foreach (GameObject switchObj in switches)
        {
            switchObj.GetComponent<Renderer>().material.color = Color.red; // Turn off the switch
        }
    }
}