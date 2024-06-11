using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExerciseTriggerScript : MonoBehaviour
{
    public PlayerPositionScript savePlayerPosition;
    public Transform playerPosition;
    public TMP_Text exerciseText;
    public GameObject boxCollider;
    public Animator transition;
    
    private bool isPlayerInRange = false;
    public float transitionTime = 1.0f;

    void Start() {
        exerciseText.gameObject.SetActive(false);
    }

    void Update() {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) {

            if (boxCollider.layer == 8) {

                StartCoroutine(SceneLoader(2));
                ProgramPanelsBoolScript.squatBool = true;

            } else if (boxCollider.layer == 9) {

                StartCoroutine(SceneLoader(7));
                ProgramPanelsBoolScript.bicepCurlBool = true;

            } else if (boxCollider.layer == 10) {

                StartCoroutine(SceneLoader(8));
                ProgramPanelsBoolScript.frontRaiseBool = true;

            } else if (boxCollider.layer == 11) {

                StartCoroutine(SceneLoader(10));
                ProgramPanelsBoolScript.jumpingJackBool = true;

            } else if (boxCollider.layer == 12) {

                StartCoroutine(SceneLoader(6));
                ProgramPanelsBoolScript.pistoSquatBool = true;

            } else if (boxCollider.layer == 13) {

                StartCoroutine(SceneLoader(5));
                ProgramPanelsBoolScript.pushupBool = true;

            } else if (boxCollider.layer == 14) {

                StartCoroutine(SceneLoader(9));
                ProgramPanelsBoolScript.sprintBool = true;

            } else if (boxCollider.layer == 15) {

                StartCoroutine(SceneLoader(11));
                ProgramPanelsBoolScript.situpBool = true;

            } else if (boxCollider.layer == 16) {

                StartCoroutine(SceneLoader(3));
                ProgramPanelsBoolScript.snatchBool = true;

            } else if (boxCollider.layer == 17) {

                StartCoroutine(SceneLoader(4));
                ProgramPanelsBoolScript.highPullBool = true;
                
            }
            
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {

            if (boxCollider.layer == 8) {
                exerciseText.text = "Squat [E]";
            } else if (boxCollider.layer == 9) {
                exerciseText.text = "Bicep Curl [E]";
            } else if (boxCollider.layer == 10) {
                exerciseText.text = "Front Raise [E]";
            } else if (boxCollider.layer == 11) {
                exerciseText.text = "Jumping Jack [E]";
            } else if (boxCollider.layer == 12) {
                exerciseText.text = "Pistol Squat [E]";
            } else if (boxCollider.layer == 13) {
                exerciseText.text = "Pushup [E]";
            } else if (boxCollider.layer == 14) {
                exerciseText.text = "Sprint [E]";
            } else if (boxCollider.layer == 15) {
                exerciseText.text = "Situp [E]";
            } else if (boxCollider.layer == 16) {
                exerciseText.text = "Snatch [E]";
            } else if (boxCollider.layer == 17) {
                exerciseText.text = "High Pull [E]";
            }

            exerciseText.gameObject.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            exerciseText.gameObject.SetActive(false);
            isPlayerInRange = false;
        }
    }

    IEnumerator SceneLoader(int levelIndex) {
        savePlayerPosition.SavePlayerPosition(playerPosition.transform.position.x, playerPosition.transform.position.y, playerPosition.transform.position.z);
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
