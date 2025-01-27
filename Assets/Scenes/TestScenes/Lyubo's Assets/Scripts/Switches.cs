using UnityEngine;

public class Switches : MonoBehaviour
{
    public int switchIndex;
    private SwitchLogic switchPattern;

    void Start()
    {
        switchPattern = FindObjectOfType<SwitchLogic>();
    }

    void OnMouseDown()
    {
        switchPattern.OnSwitchClicked(switchIndex);
        Debug.Log("0");
    }
}