using UnityEngine;

public class CodeLockButton : MonoBehaviour
{
    [SerializeField]
    private CodeLockLogic codeLockLogic;

    [SerializeField]
    private string digit;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, GlobalSettings.maxClickDistance))
        {
            if (hit.transform == transform)
            {
                if (codeLockLogic != null)
                {
                    codeLockLogic.AddDigit(digit);
                }
            }
        }
    }
}
