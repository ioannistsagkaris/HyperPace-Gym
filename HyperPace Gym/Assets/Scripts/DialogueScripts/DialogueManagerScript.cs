using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public GameObject dialoguePanel, shopPanel;
    public GameObject talkText;
    public DialogueButtonScript programButton;
    private bool isCursorLocked = false;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Button StrengthButton;
    public Button HypertrophyButton;
    public Button FatLossButton;

    public Queue<string> sentences;
    private Button[] buttons;

    public bool question = false;
    private int selectedButtonIndex = 2;
    
    void Start() {
        sentences = new Queue<string>();
        buttons = new Button[] { StrengthButton, HypertrophyButton, FatLossButton };

        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);

        StrengthButton.onClick.AddListener(() => OnButtonClick("Strength"));
        HypertrophyButton.onClick.AddListener(() => OnButtonClick("Hypertrophy"));
        FatLossButton.onClick.AddListener(() => OnButtonClick("FatLoss"));
    }

    void Update() {

        if (StrengthButton.gameObject.activeSelf && HypertrophyButton.gameObject.activeSelf && FatLossButton.gameObject.activeSelf) {
            question = true;
            HandleInput();
        }

    }

    public void StartTrainerDialogue(DialogueScript dialogue) {

        dialoguePanel.SetActive(true);
        ThirdPersonController.isDialogueActive = true;
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void StartNutritionistDialogue(DialogueScript dialogue) {

        dialoguePanel.SetActive(true);
        ThirdPersonController.isDialogueActive = true;
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void StartSellerDialogue(DialogueScript dialogue) {

        shopPanel.SetActive(true);
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isCursorLocked;
        dialoguePanel.SetActive(true);
        ThirdPersonController.isDialogueActive = true;
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {

        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }

        if (sentence.Contains("What is your goal?") || sentence.Contains("What diet plan you want to follow?"))
            ShowQuestion();
    }

    public void EndDialogue() {

        talkText.SetActive(true);
        DialogueTriggerAreaScript.dialogueStarted = false;
        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);
        ThirdPersonController.isDialogueActive = false;
        dialoguePanel.SetActive(false);
        question = false;
        selectedButtonIndex = 2;
        StopAllCoroutines();
        shopPanel.SetActive(false);
        Cursor.lockState = !isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = isCursorLocked;

    }

    private void ShowQuestion() {

        StrengthButton.gameObject.SetActive(true);
        HypertrophyButton.gameObject.SetActive(true);
        FatLossButton.gameObject.SetActive(true);

        HighlightButton(selectedButtonIndex);
        StartCoroutine(WaitForKeyPressCoroutine());

    }

    private void HandleInput() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            selectedButtonIndex = (selectedButtonIndex + 1) % 3;
            HighlightButton(selectedButtonIndex);

        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {

            selectedButtonIndex = (selectedButtonIndex + 2) % 3;
            HighlightButton(selectedButtonIndex);

        }

    }

    private IEnumerator WaitForKeyPressCoroutine() {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        OnButtonClick(buttons[selectedButtonIndex].GetComponentInChildren<TMP_Text>().text);
        
        DisplayNextSentence();
        question = false; 
    }

    private void HighlightButton(int index) {

        buttons[0].GetComponent<Image>().color = Color.gray;
        buttons[1].GetComponent<Image>().color = Color.gray;
        buttons[2].GetComponent<Image>().color = Color.gray;
        buttons[index].GetComponent<Image>().color = Color.white;

    }

    private void OnButtonClick(string programPlan) {

        if (DialogueTriggerAreaScript.inTrainersRange)
            programButton.SetProgram(programPlan);

        else if (DialogueTriggerAreaScript.inNutritionistsRange)
            programButton.SetPlan(programPlan);

        StrengthButton.gameObject.SetActive(false);
        HypertrophyButton.gameObject.SetActive(false);
        FatLossButton.gameObject.SetActive(false);
        
    }
}
