using System.IO;
using UnityEngine;

public class DialogueButtonScript : MonoBehaviour
{
    public GameObject strengthPanelProgram;
    public GameObject hyperPanelProgram;
    public GameObject fatlossPanelProgram;

    public GameObject strengthPanelPlan;
    public GameObject hyperPanelPlan;
    public GameObject fatlossPanelPlan;

    public ProgramExercisesScript programExercises;
    public ProgramDietScript programDiet;
    
    void Awake() {

        strengthPanelProgram.SetActive(false);
        hyperPanelProgram.SetActive(false);
        fatlossPanelProgram.SetActive(false);

        strengthPanelPlan.SetActive(false);
        hyperPanelPlan.SetActive(false);
        fatlossPanelPlan.SetActive(false);

    }

    public void SetProgram(string trainingProgram) {

        programDiet.SaveProgram(trainingProgram);
        programExercises.ShowExerciseTriggers(trainingProgram);
        DisplayPanelProgram(trainingProgram);
        
    }

    public void SetPlan(string dietPlan) {

        programDiet.SaveDiet(dietPlan);
        DisplayPanelPlan(dietPlan);
        
    }

    public void DisplayPanelProgram(string trainingProgram) {

        if (trainingProgram == "Strength") {

            strengthPanelProgram.SetActive(true);
            hyperPanelProgram.SetActive(false);
            fatlossPanelProgram.SetActive(false);

        } else if (trainingProgram == "Hypertrophy") {

            strengthPanelProgram.SetActive(false);
            hyperPanelProgram.SetActive(true);
            fatlossPanelProgram.SetActive(false);

        } else if (trainingProgram == "FatLoss") {

            strengthPanelProgram.SetActive(false);
            hyperPanelProgram.SetActive(false);
            fatlossPanelProgram.SetActive(true);

        }
        
    }

    public void DisplayPanelPlan(string dietPlan) {

        if (dietPlan == "Strength") {

            strengthPanelPlan.SetActive(true);
            hyperPanelPlan.SetActive(false);
            fatlossPanelPlan.SetActive(false);

        } else if (dietPlan == "Hypertrophy") {

            strengthPanelPlan.SetActive(false);
            hyperPanelPlan.SetActive(true);
            fatlossPanelPlan.SetActive(false);

        } else if (dietPlan == "FatLoss") {

            strengthPanelPlan.SetActive(false);
            hyperPanelPlan.SetActive(false);
            fatlossPanelPlan.SetActive(true);

        }
        
    }
}
