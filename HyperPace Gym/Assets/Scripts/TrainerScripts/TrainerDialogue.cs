using UnityEngine;


[System.Serializable]
public class TrainerDialogue : MonoBehaviour
{
    public new string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
