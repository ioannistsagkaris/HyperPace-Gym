using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{
    public DialogueScript trainerDialogue;
    public DialogueScript nutritionistDialogue;

    public void TriggerTrainerDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartTrainerDialogue(trainerDialogue);
    }

    public void TriggerNutritionistDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartNutritionistDialogue(nutritionistDialogue);
    }
}
