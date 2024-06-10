using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public new string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
