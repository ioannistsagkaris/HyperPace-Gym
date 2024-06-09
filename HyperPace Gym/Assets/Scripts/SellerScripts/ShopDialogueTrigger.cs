using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDialogueTrigger : MonoBehaviour
{
    public ShopDialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<ShopDialogueManager>().StartDialogue(dialogue);
    }

}