using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentRsolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentRsolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRsolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (File.Exists(Application.persistentDataPath + "/Volume.txt") && File.ReadAllText(Application.persistentDataPath + "/Volume.txt") != null && File.ReadAllText(Application.persistentDataPath + "/Volume.txt") != "")
            volumeSlider.value = float.Parse(File.ReadAllText(Application.persistentDataPath + "/Volume.txt"));
        
        if (File.Exists(Application.persistentDataPath + "/Sensitivity.txt") && File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt") != null && File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt") != "")
            sensitivitySlider.value = float.Parse(File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt"));

        if (File.Exists(Application.persistentDataPath + "/Fullscreen.txt") && File.ReadAllText(Application.persistentDataPath + "/Fullscreen.txt") != null && File.ReadAllText(Application.persistentDataPath + "/Fullscreen.txt") != "")
            fullscreenToggle.isOn = bool.Parse(File.ReadAllText(Application.persistentDataPath + "/Fullscreen.txt"));
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
        File.WriteAllText(Application.persistentDataPath + "/Volume.txt", volume.ToString());
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
        File.WriteAllText(Application.persistentDataPath + "/Fullscreen.txt", isFullscreen.ToString());
    }

    public void SetSensitivity(float sensitivity) {
        File.WriteAllText(Application.persistentDataPath + "/Sensitivity.txt", sensitivity.ToString());
    }
}
