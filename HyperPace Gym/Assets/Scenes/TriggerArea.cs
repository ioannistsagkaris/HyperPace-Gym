using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerArea : MonoBehaviour
{
    public GameObject talkText; 
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    private bool isPlayerInRange = false;
    public bool dialogueStarted = false;

    void Start()
    {
        talkText.SetActive(false); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talkText.SetActive(true); 
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talkText.SetActive(false);
            isPlayerInRange = false;
            dialogueStarted = false; 
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueStarted)
            {
                dialogueTrigger.TriggerDialogue();
                dialogueStarted = true;
                talkText.SetActive(false); 
            }
            
            dialogueManager.DisplayNextSentence();            
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.EndDialogue();
        }
    }
}
