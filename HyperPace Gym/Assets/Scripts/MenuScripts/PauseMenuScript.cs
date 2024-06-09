using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public SceneDataManagerScript sceneDataManager;
    public GameObject pauseMenuUI;
    
    public static bool gameIsPaused = false;
    private bool isCursorLocked = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        Cursor.lockState = !isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = isCursorLocked;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isCursorLocked;
    }

    public void StopGame() {
        sceneDataManager.SaveData(new Vector3((float)-11.71, (float)3.85299993, (float)6.69999981), "");
        Application.Quit();
    }
}
