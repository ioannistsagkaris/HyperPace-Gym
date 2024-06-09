using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public Toggle fullscreenToggle;
    
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/Volume.txt") && File.ReadAllText(Application.persistentDataPath + "/Volume.txt") != null && File.ReadAllText(Application.persistentDataPath + "/Volume.txt") != "")
            volumeSlider.value = float.Parse(File.ReadAllText(Application.persistentDataPath + "/Volume.txt"));
        
        if (File.Exists(Application.persistentDataPath + "/Sensitivity.txt") && File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt") != null && File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt") != "")
            sensitivitySlider.value = float.Parse(File.ReadAllText(Application.persistentDataPath + "/Sensitivity.txt"));

        if (File.Exists(Application.persistentDataPath + "/Fullscreen.txt") && File.ReadAllText(Application.persistentDataPath + "/Fullscreen.txt") != null && File.ReadAllText(Application.persistentDataPath + "/Fullscreen.txt") != "")
            fullscreenToggle.isOn = bool.Parse(File.ReadAllText(Application.persistentDataPath + "/Fullscreen.txt"));
    }
}
