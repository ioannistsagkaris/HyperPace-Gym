using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{
    public DialogueScript trainerDialogue;
    public DialogueScript nutritionistDialogue;
    public DialogueScript sellerDialogue;

    public DialogueScript trainerProgressDialogue1;
    public DialogueScript trainerProgressDialogue2;
    public DialogueScript trainerProgressDialogue3;

    public void TriggerTrainerDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(trainerDialogue);
    }

    public void TriggerNutritionistDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(nutritionistDialogue);
    }

    public void TriggerSellerDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartShop(sellerDialogue);
    }

    public void TriggerTrainerProgressDialogue1() {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(trainerProgressDialogue1);
    }

    public void TriggerTrainerProgressDialogue2() {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(trainerProgressDialogue2);
    }

    public void TriggerTrainerProgressDialogue3() {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(trainerProgressDialogue3);
    }
}
