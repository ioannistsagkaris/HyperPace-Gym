// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class DialogueManager : MonoBehaviour
// {
//     public TMP_Text nameText;
//     public TMP_Text dialogueText;
//     public Animator animator;
//     public GameObject talkText;
//     public TriggerArea triggerArea;
//     private Queue<string> sentences;

//     void Start()
//     {
//         sentences = new Queue<string>();
//     }

//     public void StartDialogue(Dialogue dialogue)
//     {
//         animator.SetBool("IsOpen", true);
//         nameText.text = dialogue.name;
//         sentences.Clear();

//         foreach (string sentence in dialogue.sentences)
//         {
//             sentences.Enqueue(sentence);
//         }

//         DisplayNextSentence();
//     }

//     public void DisplayNextSentence()
//     {
//         animator.SetBool("IsOpen", true);
//         if (sentences.Count == 0)
//         {
//             EndDialogue();
//             return;
//         }

//         string sentence = sentences.Dequeue();
//         StopAllCoroutines();
//         StartCoroutine(TypeSentence(sentence));
//     }

//     IEnumerator TypeSentence(string sentence)
//     {
//         dialogueText.text = "";
//         foreach (char letter in sentence.ToCharArray())
//         {
//             dialogueText.text += letter;
//             yield return null;
//         }
//     }

//     public void EndDialogue()
//     {
//         animator.SetBool("IsOpen", false);
//         talkText.SetActive(true);
//         triggerArea.dialogueStarted = false;
        
//     }
// }

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    public GameObject talkText;
    public TriggerArea triggerArea;
    public Button yesButton;
    public Button noButton;

    private Queue<string> sentences;
    private int selectedButtonIndex = 0;
    private Button[] buttons;

    void Start()
    {
        sentences = new Queue<string>();
        buttons = new Button[] { yesButton, noButton };

        
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        
        yesButton.onClick.AddListener(() => OnButtonClick(true));
        noButton.onClick.AddListener(() => OnButtonClick(false));
    }

    void Update()
    {
        if (yesButton.gameObject.activeSelf && noButton.gameObject.activeSelf)
        {
            HandleInput();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        animator.SetBool("IsOpen", true);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        // After typing the sentence, show Yes/No question if needed
        if (sentence.Contains("Do you want to continue?"))
        {
            ShowYesNoQuestion();
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        talkText.SetActive(true);
        triggerArea.dialogueStarted = false;
    }

    private void ShowYesNoQuestion()
    {
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        HighlightButton(selectedButtonIndex);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.N))
        {
            selectedButtonIndex = 1 - selectedButtonIndex;
            HighlightButton(selectedButtonIndex);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedButtonIndex == 0)
            {
                OnButtonClick(true);
            }
            else
            {
                OnButtonClick(false);
            }
        }
    }

    private void HighlightButton(int index)
    {
        buttons[0].GetComponent<Image>().color = Color.white;
        buttons[1].GetComponent<Image>().color = Color.white;
        buttons[index].GetComponent<Image>().color = Color.green;
    }

    private void OnButtonClick(bool isYes)
    {
        string playerAnswer = isYes ? "Yes" : "No";
        
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        
        NextDialogue(playerAnswer);
    }

    private void NextDialogue(string playerAnswer)
    {
        
        if (playerAnswer == "Yes")
        {
            dialogueText.text = "You chose Yes!";
        }
        else
        {
            dialogueText.text = "You chose No!";
        }
        
    }
}
