using UnityEngine;

public class CodeLockButton : MonoBehaviour
{
    [SerializeField]
    private CodeLockLogic codeLockLogic;

    [SerializeField]
    private string digit;

    private void OnMouseDown()
    {
        if (codeLockLogic != null)
        {
            codeLockLogic.AddDigit(digit);
        }
    }
}
