using System;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public event Action<GameObject> OnButtonPressed;

    public void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, GlobalSettings.maxClickDistance))
        {
            if (hit.transform == transform)
            {
                if (OnButtonPressed != null)
                {
                    Debug.Log($"Pressed button: {gameObject.name}");
                    OnButtonPressed(gameObject);
                }
                else
                {
                    Debug.LogWarning("No handler subscribed to OnButtonPressed!");
                }
            }
        }
    }
}
