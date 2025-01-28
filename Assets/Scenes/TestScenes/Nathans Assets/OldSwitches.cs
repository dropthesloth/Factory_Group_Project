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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 5f;
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.transform == transform)
            {
                switchPattern.OnSwitchClicked(switchIndex);
                Debug.Log("0");
            }
        }
    }
}
