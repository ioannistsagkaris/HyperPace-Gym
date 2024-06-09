using UnityEngine;

public class NutritionTriggerArea : MonoBehaviour
{
    public GameObject talkText;
    public NutritionDialogueTrigger dialogueTrigger;
    public NutritionDialogueManager dialogueManager;
    
    public bool dialogueStarted = false;
    private bool isPlayerInRange = false;
    

    void Start() {
        talkText.SetActive(false);        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            talkText.SetActive(true);
            isPlayerInRange = true;
        }

    }

    void OnTriggerExit(Collider other) {

        if (other.CompareTag("Player")) {
            talkText.SetActive(false);
            isPlayerInRange = false;
            dialogueStarted = false;
        }

    }

    void Update() {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !dialogueManager.question) {

            if (!dialogueStarted) {
                dialogueTrigger.TriggerDialogue();
                dialogueStarted = true;
                talkText.SetActive(false);
            }

            dialogueManager.DisplayNextSentence();
        } else if (isPlayerInRange && Input.GetKeyDown(KeyCode.Escape) && dialogueStarted)
            dialogueManager.EndDialogue();
    }
}
