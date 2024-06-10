using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{
    public TrainerDialogueScript trainerDialogue;
    public NutritionistDialogueScript nutritionistDialogue;

    public void TriggerTrainerDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartTrainerDialogue(trainerDialogue);
    }

    public void TriggerNutritionistDialogue() {
        FindObjectOfType<DialogueManagerScript>().StartNutritionistDialogue(nutritionistDialogue);
    }
}
