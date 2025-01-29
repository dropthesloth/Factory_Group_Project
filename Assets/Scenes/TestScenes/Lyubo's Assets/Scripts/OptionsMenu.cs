using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;
    public Slider volumeSlider;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (
                resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height
            )
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionIndex", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        qualityDropdown.value = PlayerPrefs.GetInt(
            "qualityIndex",
            QualitySettings.GetQualityLevel()
        );
        qualityDropdown.RefreshShownValue();

        fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        vsyncToggle.isOn = PlayerPrefs.GetInt("vsync", 1) == 1;
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.75f);

        ApplySettings();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
    }

    public void SetVSync(bool isVSync)
    {
        QualitySettings.vSyncCount = isVSync ? 1 : 0;
        PlayerPrefs.SetInt("vsync", isVSync ? 1 : 0);
    }

    public void ApplySettings()
    {
        SetResolution(PlayerPrefs.GetInt("resolutionIndex", 0));
        SetQuality(PlayerPrefs.GetInt("qualityIndex", QualitySettings.GetQualityLevel()));
        SetFullscreen(PlayerPrefs.GetInt("fullscreen", 1) == 1);
        SetVSync(PlayerPrefs.GetInt("vsync", 1) == 1);
        SetVolume(PlayerPrefs.GetFloat("volume", 0.75f));
    }

    public void Back(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
