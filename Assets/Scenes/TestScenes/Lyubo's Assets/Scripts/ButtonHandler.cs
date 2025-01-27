using System;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public event Action<GameObject> OnButtonPressed;

    public void OnMouseDown()
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
