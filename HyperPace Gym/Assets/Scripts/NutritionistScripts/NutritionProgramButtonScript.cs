using UnityEngine;

public class NutritionProgramButton : MonoBehaviour
{
    public GameObject strengthPanel, hyperPanel, fatlossPanel;
    public ProgramDietScript programDiet;
    
    void Start() {
        strengthPanel.SetActive(false);
        hyperPanel.SetActive(false);
        fatlossPanel.SetActive(false);
    }

    public void SetProgram(string diet) {
        programDiet.SaveDiet(diet);
        DisplayPanel(diet);
    }

    public void DisplayPanel(string diet) {

        if (diet == "Strength") {

            strengthPanel.SetActive(true);
            hyperPanel.SetActive(false);
            fatlossPanel.SetActive(false);

        } else if (diet == "Hypertrophy") {

            strengthPanel.SetActive(false);
            hyperPanel.SetActive(true);
            fatlossPanel.SetActive(false);

        } else if (diet == "FatLoss") {

            strengthPanel.SetActive(false);
            hyperPanel.SetActive(false);
            fatlossPanel.SetActive(true);
            
        }
        
    }
}
