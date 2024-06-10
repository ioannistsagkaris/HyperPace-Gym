using UnityEngine;

public class DialogueTriggerAreaScript : MonoBehaviour
{
    public GameObject talkText;
    public GameObject boxCollider;

    public DialogueTriggerScript dialogueTrigger;
    public DialogueManagerScript dialogueManager;

    public static bool dialogueStarted = false;
    public static bool inTrainersRange = false;
    public static bool inNutritionistsRange = false;
    public static bool inSellerRange = false;
    private bool isPlayerInRange = false;
    
    void Start() {
        talkText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            talkText.SetActive(true);
            isPlayerInRange = true;

            if (boxCollider.layer == 19)
                inTrainersRange = true;

            else if (boxCollider.layer == 20)
                inNutritionistsRange = true;

            else if (boxCollider.layer == 21)
                inSellerRange = true;
        }

    }

    private void OnTriggerExit(Collider other) {

        if (other.CompareTag("Player")) {

            talkText.SetActive(false);
            isPlayerInRange = false;
            dialogueStarted = false;
            inTrainersRange = false;
            inNutritionistsRange = false;
            inSellerRange = false;

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

            } 
            else if (inNutritionistsRange) {

                if (!dialogueStarted) {

                    dialogueTrigger.TriggerNutritionistDialogue();
                    dialogueStarted = true;
                    talkText.SetActive(false);

                }

            }
            else if (inSellerRange) {

                if (!dialogueStarted) {

                    dialogueTrigger.TriggerSellerDialogue();
                    dialogueStarted = true;
                    talkText.SetActive(false);

                }

            }

            dialogueManager.DisplayNextSentence();

        } else if (isPlayerInRange && Input.GetKeyDown(KeyCode.X) && dialogueStarted)
            dialogueManager.EndDialogue();
    }

}
