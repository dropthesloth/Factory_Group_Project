using UnityEngine;

public class OldSwitches : MonoBehaviour
{
    public int switchIndex;
    private OldSwitchLogic switchPattern;

    void Start()
    {
        switchPattern = FindObjectOfType<OldSwitchLogic>();
    }

    void OnMouseDown()
    {
        switchPattern.OnSwitchClicked(switchIndex);
    }
}