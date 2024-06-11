using UnityEngine;

public class ProgramDietScript : MonoBehaviour
{
    public DialogueButtonScript panels;
    public ProgramExercisesScript programExercises;

    private string trainingProgram = string.Empty;
    private string dietPlan = string.Empty;

    void Start() {
        LoadProgram();
        LoadDiet();
    }

    public void SaveProgram(string program) {
        PlayerPrefs.SetString("TrainingProgram", program);
    }

    public void SaveDiet(string diet) {
        PlayerPrefs.SetString("DietPlan", diet);
    }

    public void LoadProgram() {
        trainingProgram = PlayerPrefs.GetString("TrainingProgram");

        if (!string.IsNullOrEmpty(trainingProgram)) {
            panels.DisplayPanelProgram(trainingProgram);
            programExercises.ShowExerciseTriggers(trainingProgram);
        }
    }

    public void LoadDiet() {
        dietPlan = PlayerPrefs.GetString("DietPlan");

        if (!string.IsNullOrEmpty(dietPlan))
            panels.DisplayPanelPlan(dietPlan);
    }
}
