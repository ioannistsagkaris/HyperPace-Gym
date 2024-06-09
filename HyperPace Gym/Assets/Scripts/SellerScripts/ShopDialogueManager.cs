using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class ShopDialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    public ShopTriggerArea triggerArea, talkText;
    public Button StrengthButton;
    public Button FatLossButton;
    public Button HypertrophyButton;
    public ThirdPersonController playerController; 
    public GameObject dialoguePanel;
    public ShopProgramButton programButton;
    public bool question = false;

    public Queue<string> sentences;
    private int selectedButtonIndex = 0;
    private Button[] buttons;
    
    void Start()
    {
        sentences = new Queue<string>();
        buttons = new Button[] { FatLossButton, HypertrophyButton, StrengthButton};

        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);

        StrengthButton.onClick.AddListener(() => OnButtonClick("Strength"));
        FatLossButton.onClick.AddListener(() => OnButtonClick("FatLoss"));
        HypertrophyButton.onClick.AddListener(() => OnButtonClick("Hypertrophy"));
    }

    void Update()
    {
        if (StrengthButton.gameObject.activeSelf && HypertrophyButton.gameObject.activeSelf && FatLossButton.gameObject.activeSelf)
        {
            question = true;
            HandleInput();
        }
    }

    public void StartDialogue(ShopDialogue dialogue)
    {
        dialoguePanel.SetActive(true);
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
        if (sentence.Contains("What do you need?"))
        {
            ShowQuestion();
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        triggerArea.talkText.SetActive(true);
        triggerArea.dialogueStarted = false;
        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);
        playerController.isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    private void ShowQuestion()
    {
        StrengthButton.gameObject.SetActive(true);
        HypertrophyButton.gameObject.SetActive(true);
        FatLossButton.gameObject.SetActive(true);
        HighlightButton(selectedButtonIndex);
        StartCoroutine(WaitForKeyPressCoroutine());
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedButtonIndex = (selectedButtonIndex - 1 + 3) % 3; 
            HighlightButton(selectedButtonIndex);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedButtonIndex = (selectedButtonIndex + 1) % 3;
            HighlightButton(selectedButtonIndex);
        }
    }

    private IEnumerator WaitForKeyPressCoroutine()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        OnButtonClick(buttons[selectedButtonIndex].GetComponentInChildren<TMP_Text>().text);
        
        DisplayNextSentence();
        question = false; 
    }

    private void HighlightButton(int index)
    {
        buttons[0].GetComponent<Image>().color = Color.gray;
        buttons[1].GetComponent<Image>().color = Color.grey;
        buttons[2].GetComponent<Image>().color = Color.gray;
        buttons[index].GetComponent<Image>().color = Color.white;
    }

    private void OnButtonClick(string program)
    {
        programButton.SetProgram(program); 
        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);
    }
}
