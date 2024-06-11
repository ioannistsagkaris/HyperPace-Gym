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
    public ProgramPanelsBoolScript programPanelBool;
    
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

            if (ProgramPanelsBoolScript.squatBool) {

                programPanelBool.squat.SetActive(false);
                programPanelBool.squatRemoved.SetActive(true);

            } else {

                programPanelBool.squatRemoved.SetActive(false);
                programPanelBool.squat.SetActive(true);
            }

            if (ProgramPanelsBoolScript.snatchBool) {

                programPanelBool.snatch.SetActive(false);
                programPanelBool.snatchRemoved.SetActive(true);

            } else {

                programPanelBool.snatchRemoved.SetActive(false);
                programPanelBool.snatch.SetActive(true);
            }

            if (ProgramPanelsBoolScript.highPullBool) {

                programPanelBool.highPull.SetActive(false);
                programPanelBool.highPullRemoved.SetActive(true);

            } else {

                programPanelBool.highPullRemoved.SetActive(false);
                programPanelBool.highPull.SetActive(true);

            }

        } else if (trainingProgram == "Hypertrophy") {

            strengthPanelProgram.SetActive(false);
            hyperPanelProgram.SetActive(true);
            fatlossPanelProgram.SetActive(false);

            if (ProgramPanelsBoolScript.pushupBool) {

                programPanelBool.pushup.SetActive(false);
                programPanelBool.pushupRemoved.SetActive(true);

            } else {

                programPanelBool.pushupRemoved.SetActive(false);
                programPanelBool.pushup.SetActive(true);

            }

            if (ProgramPanelsBoolScript.bicepCurlBool) {

                programPanelBool.bicepCurl.SetActive(false);
                programPanelBool.bicepCurlRemoved.SetActive(true);

            } else {

                programPanelBool.bicepCurlRemoved.SetActive(false);
                programPanelBool.bicepCurl.SetActive(true);

            }

            if (ProgramPanelsBoolScript.frontRaiseBool) {

                programPanelBool.frontRaise.SetActive(false);
                programPanelBool.frontRaiseRemoved.SetActive(true);
                
            } else {

                programPanelBool.frontRaiseRemoved.SetActive(false);
                programPanelBool.frontRaise.SetActive(true);

            }

            if (ProgramPanelsBoolScript.pistoSquatBool) {

                programPanelBool.pistolSquat.SetActive(false);
                programPanelBool.pistolSquatRemoved.SetActive(true);

            } else {

                programPanelBool.pistolSquatRemoved.SetActive(false);
                programPanelBool.pistolSquat.SetActive(true);

            }

        } else if (trainingProgram == "FatLoss") {

            strengthPanelProgram.SetActive(false);
            hyperPanelProgram.SetActive(false);
            fatlossPanelProgram.SetActive(true);

            if (ProgramPanelsBoolScript.sprintBool) {

                programPanelBool.sprint.SetActive(false);
                programPanelBool.sprintRemoved.SetActive(true);

            } else {

                programPanelBool.sprintRemoved.SetActive(false);
                programPanelBool.sprint.SetActive(true);

            }

            if (ProgramPanelsBoolScript.jumpingJackBool) {

                programPanelBool.jumpingJack.SetActive(false);
                programPanelBool.jumpingJackRemoved.SetActive(true);

            } else {

                programPanelBool.jumpingJackRemoved.SetActive(false);
                programPanelBool.jumpingJack.SetActive(true);

            }

            if (ProgramPanelsBoolScript.situpBool) {

                programPanelBool.situp.SetActive(false);
                programPanelBool.situpRemoved.SetActive(true);

            } else {

                programPanelBool.situpRemoved.SetActive(false);
                programPanelBool.situp.SetActive(true);
                
            }

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
