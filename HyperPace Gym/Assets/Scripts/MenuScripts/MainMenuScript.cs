using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;
    private bool isCursorLocked = false;

    public void StartGame() {
        Cursor.lockState = !isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = isCursorLocked;
        StartCoroutine(SceneLoader(1));
    }

    public void StopGame() {
        Application.Quit();
    }

    IEnumerator SceneLoader(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
