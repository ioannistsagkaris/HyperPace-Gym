using System.IO;
using UnityEngine;

public class ReadGender : MonoBehaviour
{
    public GameObject malePlayer;
    public GameObject maleCamera;
    public GameObject femalePlayer;
    public GameObject femaleCamera;

    void Start() {
        if (File.ReadAllText(Application.persistentDataPath + "/Gender.txt") == "Female") {
            malePlayer.SetActive(false);
            maleCamera.SetActive(false);
            femalePlayer.SetActive(true);
            femaleCamera.SetActive(true);
        }
        else {
            femalePlayer.SetActive(false);
            femaleCamera.SetActive(false);
            malePlayer.SetActive(true);
            maleCamera.SetActive(true);
        }
    }
}
