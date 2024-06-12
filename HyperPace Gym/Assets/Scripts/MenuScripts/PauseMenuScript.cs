using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PlayerPositionScript savePlayerPosition;
    public ProgramDietScript programDiet;
    
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
        savePlayerPosition.SavePlayerPosition((float)-11.71, (float)3.853, (float)6.7);
        programDiet.SaveProgram(string.Empty);
        programDiet.SaveDiet(string.Empty);
        Application.Quit();
    }
}
