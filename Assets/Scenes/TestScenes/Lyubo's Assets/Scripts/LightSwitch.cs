using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public float exposureIncreaseAmount = 0.1f; // Amount to increase the exposure by
    private float originalExposure; // Store the original exposure value

    private void Start()
    {
        // Store the original exposure value at the start
        if (RenderSettings.skybox.HasProperty("_Exposure"))
        {
            originalExposure = RenderSettings.skybox.GetFloat("_Exposure");
        }
        else
        {
            Debug.LogError("Skybox material does not have an _Exposure property.");
        }
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, GlobalSettings.maxClickDistance))
        {
            if (hit.transform == transform)
            {
                // Increase the skybox exposure
                if (RenderSettings.skybox.HasProperty("_Exposure"))
                {
                    float currentExposure = RenderSettings.skybox.GetFloat("_Exposure");
                    RenderSettings.skybox.SetFloat(
                        "_Exposure",
                        currentExposure + exposureIncreaseAmount
                    );
                }
                else
                {
                    Debug.LogError("Skybox material does not have an _Exposure property.");
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        // Reset the exposure to the original value when the application quits
        if (RenderSettings.skybox.HasProperty("_Exposure"))
        {
            RenderSettings.skybox.SetFloat("_Exposure", originalExposure);
        }
    }

#if UNITY_EDITOR
    private void OnDisable()
    {
        // Reset the exposure to the original value when exiting play mode in the editor
        if (RenderSettings.skybox.HasProperty("_Exposure"))
        {
            RenderSettings.skybox.SetFloat("_Exposure", originalExposure);
        }
    }
#endif
}
