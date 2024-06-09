using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataManagerScript : MonoBehaviour
{
    public SceneDataScript sceneData;

    void Awake() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SaveData(Vector3 position, string program) {
        sceneData.position = position;
        sceneData.program = program;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

        if (scene.buildIndex == 1) {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) {
                if (sceneData.position == new Vector3(0, 0, 0))
                    player.transform.position = new Vector3((float)-11.71, (float)3.85299993, (float)6.69999981);
                else
                    player.transform.position = sceneData.position;
            }
        }

    }
}
