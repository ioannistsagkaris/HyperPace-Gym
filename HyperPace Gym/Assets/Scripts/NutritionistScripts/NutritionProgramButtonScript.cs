using UnityEngine;

public class NutritionProgramButton : MonoBehaviour
{
    public GameObject strengthPanel, hyperPanel, fatlossPanel;

    private string training_program; 
    
    void Start() {
        strengthPanel.SetActive(false);
        hyperPanel.SetActive(false);
        fatlossPanel.SetActive(false);
    }

    public void SetProgram(string program) {
        training_program = program;
        DisplayPanel();
    }

    private void DisplayPanel() {

        if (training_program == "Strength") {

            strengthPanel.SetActive(true);
            hyperPanel.SetActive(false);
            fatlossPanel.SetActive(false);

        } else if (training_program == "Hypertrophy") {

            strengthPanel.SetActive(false);
            hyperPanel.SetActive(true);
            fatlossPanel.SetActive(false);

        } else if (training_program == "FatLoss") {

            strengthPanel.SetActive(false);
            hyperPanel.SetActive(false);
            fatlossPanel.SetActive(true);
            
        }
        
    }
}
