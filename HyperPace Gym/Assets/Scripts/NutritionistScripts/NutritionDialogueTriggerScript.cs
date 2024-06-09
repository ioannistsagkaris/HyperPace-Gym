using UnityEngine;

public class NutritionDialogueTrigger : MonoBehaviour
{
    public NutritionDialogue dialogue;

    public void TriggerDialogue() {
        FindObjectOfType<NutritionDialogueManager>().StartDialogue(dialogue);
    }
}
