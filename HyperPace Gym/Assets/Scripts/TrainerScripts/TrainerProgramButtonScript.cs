using UnityEngine;

public class TrainerProgramButton : MonoBehaviour
{
    public GameObject strengthPanel, hyperPanel, fatlossPanel;
    public ProgramExercisesScript programExercises;
    public ProgramDietScript programDiet;
    
    void Start() {
        strengthPanel.SetActive(false);
        hyperPanel.SetActive(false);
        fatlossPanel.SetActive(false);
    }

    public void SetProgram(string trainingProgram) {
        programDiet.SaveProgram(trainingProgram);
        programExercises.ShowExerciseTriggers(trainingProgram);
        DisplayPanel(trainingProgram);
    }

    public void DisplayPanel(string trainingProgram) {

        if (trainingProgram == "Strength") {

            strengthPanel.SetActive(true);
            hyperPanel.SetActive(false);
            fatlossPanel.SetActive(false);

        } else if (trainingProgram == "Hypertrophy") {

            strengthPanel.SetActive(false);
            hyperPanel.SetActive(true);
            fatlossPanel.SetActive(false);

        } else if (trainingProgram == "FatLoss") {

            strengthPanel.SetActive(false);
            hyperPanel.SetActive(false);
            fatlossPanel.SetActive(true);

        }
        
    }
}
