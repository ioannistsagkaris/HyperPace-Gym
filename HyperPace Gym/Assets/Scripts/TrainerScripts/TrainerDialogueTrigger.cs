using UnityEngine;

public class TrainerDialogueTrigger : MonoBehaviour
{
    public TrainerDialogue dialogue;

    public void TriggerDialogue() {
        FindObjectOfType<TrainerDialogueManager>().StartDialogue(dialogue);
    }
}