using UnityEngine;

public class TrainerDialogueScript : MonoBehaviour
{
    public new string name;

    [TextArea(3, 10)]
    public string[] trainerSentences;
}
