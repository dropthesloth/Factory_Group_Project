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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, GlobalSettings.maxClickDistance))
        {
            if (hit.transform == transform)
            {
                switchPattern.OnSwitchClicked(switchIndex);
                Debug.Log("0");
            }
        }
    }
}
