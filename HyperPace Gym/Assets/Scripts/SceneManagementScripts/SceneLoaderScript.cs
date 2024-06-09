using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    Scene currentScene;
    public Animator transition;
    public float transitionTime = 1.0f;

    void Start() {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update() {
        if (currentScene.buildIndex == 0 || currentScene.buildIndex == 1)
            return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(SceneLoader(1));
    }

    IEnumerator SceneLoader(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
