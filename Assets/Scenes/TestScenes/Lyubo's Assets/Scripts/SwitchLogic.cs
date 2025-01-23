using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField]
    UnityEvent finishEvent;

    void Start()
    {
        ResetSwitches();
    }

    public void OnSwitchClicked(int switchIndex)
    {
        // Toggle the main switch
        bool newState =
            switches[switchIndex].GetComponent<Renderer>().material.color != Color.green;
        ToggleSwitch(switchIndex, newState);

        // Toggle dependent switches
        foreach (int dependentIndex in switchDependencies[switchIndex].dependentSwitchIndices)
        {
            bool dependentNewState =
                switches[dependentIndex].GetComponent<Renderer>().material.color != Color.green;
            ToggleSwitch(dependentIndex, dependentNewState);
        }

        if (AreAllSwitchesOn())
        {
            Debug.Log("All switches are on! Puzzle completed!");
            finishEvent.Invoke();
        }
    }

    private void ToggleSwitch(int switchIndex, bool newState)
    {
        Renderer renderer = switches[switchIndex].GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newState ? Color.green : Color.red;
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
            switchObj.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
