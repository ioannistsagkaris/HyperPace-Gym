using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;


public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    public GameObject talkText;
    public TriggerArea triggerArea;
    public Button StrengthButton;
    public Button FatLossButton;
    public Button HypertrophyButton;
    public ThirdPersonController playerController; 

    private Queue<string> sentences;
    private int selectedButtonIndex = 0;
    private Button[] buttons;

    void Start()
    {
        sentences = new Queue<string>();
        buttons = new Button[] { StrengthButton, HypertrophyButton,FatLossButton };

        
        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);


        
        StrengthButton.onClick.AddListener(() => OnButtonClick("Strength"));
        FatLossButton.onClick.AddListener(() => OnButtonClick("Fat Loss"));
        HypertrophyButton.onClick.AddListener(() => OnButtonClick("Hypertrophy"));
    }

    void Update()
    {
        if (StrengthButton.gameObject.activeSelf && HypertrophyButton.gameObject.activeSelf && FatLossButton.gameObject.activeSelf)
        {
            HandleInput();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerController.isDialogueActive = true;
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

        if (sentence.Contains("What is your goal?"))
        {
            ShowYesNoQuestion();
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        talkText.SetActive(true);
        triggerArea.dialogueStarted = false;
        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);
        playerController.isDialogueActive = false;
    }

    private void ShowYesNoQuestion()
    {
        StrengthButton.gameObject.SetActive(true);
        HypertrophyButton.gameObject.SetActive(true);
        FatLossButton.gameObject.SetActive(true);
        HighlightButton(selectedButtonIndex);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        selectedButtonIndex = (selectedButtonIndex + 1) % 3;
        HighlightButton(selectedButtonIndex);
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        selectedButtonIndex = (selectedButtonIndex - 1 + 3) % 3;
        HighlightButton(selectedButtonIndex);
    }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnButtonClick(buttons[selectedButtonIndex].GetComponentInChildren<TMP_Text>().text);
        }
    }

    private void HighlightButton(int index)
    {
        buttons[0].GetComponent<Image>().color = Color.white;
        buttons[1].GetComponent<Image>().color = Color.white;
        buttons[2].GetComponent<Image>().color = Color.white;
        buttons[index].GetComponent<Image>().color = Color.green;
    }

    private void OnButtonClick(string choice)
    {
        dialogueText.text = $"You chose {choice}!";

        StrengthButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);

        NextDialogue(choice);
    }

    private void NextDialogue(string playerAnswer)
    {
        
        if (playerAnswer == "Strength")
        {
            Debug.Log("Strength chosen");
        }
        else if (playerAnswer == "Fat Loss")
        {
            Debug.Log("Fat Loss chosen");
        }
        else if (playerAnswer == "Hypertrophy")
        {
            Debug.Log("Hypertrophy chosen");
        }
        
    }
}
