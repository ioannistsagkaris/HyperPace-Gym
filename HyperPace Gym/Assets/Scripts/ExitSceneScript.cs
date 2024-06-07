using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSceneScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainScene");
    }
}
