using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sensitivitySlider;
    public TMP_Dropdown resolutionDropdown;
    public Toggle toggleMan;
    public Toggle toggleWoman;
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

        string sensitivity = File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt");
        if (sensitivity != "" || sensitivity != null)
            sensitivitySlider.value = float.Parse(sensitivity);

        if (toggleMan != null && toggleWoman != null) {
            string gender = File.ReadAllText(Application.persistentDataPath + "/Gender.txt");
            if (gender != "" || gender != null) {
                if (gender == "Female") {
                    toggleMan.isOn = false;
                    toggleWoman.isOn = true;
                }
            }
        }
            
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetSensitivity(float sensitivity) {
        File.WriteAllText(Application.persistentDataPath + "/Sensitivity.txt", sensitivity.ToString());
    }
}
