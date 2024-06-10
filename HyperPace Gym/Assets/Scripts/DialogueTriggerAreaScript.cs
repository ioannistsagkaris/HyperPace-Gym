using UnityEngine;

public class DialogueTriggerAreaScript : MonoBehaviour
{
    public GameObject talkText;
    public GameObject trainerBoxCollider;
    public GameObject nutritionistBoxCollider;

    public DialogueTriggerScript dialogueTrigger;
    public DialogueManagerScript dialogueManager;

    public bool dialogueStarted = false;
    private bool isPlayerInRange = false;
    public bool inTrainersRange = false;
    public bool inNutritionistsRange = false;
    
    void Start() {
        talkText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            talkText.SetActive(true);
            isPlayerInRange = true;

            if (other.gameObject.layer == trainerBoxCollider.layer)
                inTrainersRange = true;

            else if (other.gameObject.layer == nutritionistBoxCollider.layer)
                inNutritionistsRange = true;

            Debug.Log("Trainer: " + inTrainersRange);
            Debug.Log("Nutritionist: " + inNutritionistsRange);

        }

    }

    private void OnTriggerExit(Collider other) {

        if (other.CompareTag("Player")) {

            talkText.SetActive(false);
            isPlayerInRange = false;
            dialogueStarted = false;

            if (trainerBoxCollider.layer == 19)
                inTrainersRange = false;

            else if (nutritionistBoxCollider.layer == 20)
                inNutritionistsRange = false;

        }

    }

    void Update() {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !dialogueManager.question) {

            if (inTrainersRange) {

                if (!dialogueStarted) {

                    dialogueTrigger.TriggerTrainerDialogue();
                    dialogueStarted = true;
                    talkText.SetActive(false);

                }

            } else if (inNutritionistsRange) {

                if (!dialogueStarted) {

                    dialogueTrigger.TriggerNutritionistDialogue();
                    dialogueStarted = true;
                    talkText.SetActive(false);

                }

            }

            dialogueManager.DisplayNextSentence();

        } else if (isPlayerInRange && Input.GetKeyDown(KeyCode.Escape) && dialogueStarted)
            dialogueManager.EndDialogue();
    }

}
