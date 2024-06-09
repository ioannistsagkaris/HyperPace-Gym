using UnityEngine;

public class ProgramExercisesScript : MonoBehaviour
{
    private string program = "Hypertrophy";
    public GameObject squatTrigger;
    public GameObject bicepCurlTrigger;
    public GameObject frontRaiseTrigger;
    public GameObject jumpingJackTrigger;
    public GameObject pistolSquatTrigger;
    public GameObject pushupTrigger;
    public GameObject runTrigger;
    public GameObject situpTrigger;
    public GameObject snatchTrigger;
    public GameObject highPullTrigger;

    void Start() {

        squatTrigger.SetActive(false);
        snatchTrigger.SetActive(false);
        highPullTrigger.SetActive(false);
        bicepCurlTrigger.SetActive(false);
        frontRaiseTrigger.SetActive(false);
        jumpingJackTrigger.SetActive(false);
        pistolSquatTrigger.SetActive(false);
        pushupTrigger.SetActive(false);
        runTrigger.SetActive(false);
        situpTrigger.SetActive(false);

    }

    void Update() {
        if (program == "Strength") {

            squatTrigger.SetActive(true);
            snatchTrigger.SetActive(true);
            highPullTrigger.SetActive(true);

            pushupTrigger.SetActive(false);
            bicepCurlTrigger.SetActive(false);
            frontRaiseTrigger.SetActive(false);
            pistolSquatTrigger.SetActive(false);
            runTrigger.SetActive(false);
            jumpingJackTrigger.SetActive(false);
            situpTrigger.SetActive(false);

        } else if (program == "Hypertrophy") {

            pushupTrigger.SetActive(true);
            bicepCurlTrigger.SetActive(true);
            frontRaiseTrigger.SetActive(true);
            pistolSquatTrigger.SetActive(true);

            runTrigger.SetActive(false);
            jumpingJackTrigger.SetActive(false);
            situpTrigger.SetActive(false);
            squatTrigger.SetActive(false);
            snatchTrigger.SetActive(false);
            highPullTrigger.SetActive(false);

        } else if (program == "LoseFat") {

            runTrigger.SetActive(true);
            jumpingJackTrigger.SetActive(true);
            situpTrigger.SetActive(true);

            squatTrigger.SetActive(false);
            snatchTrigger.SetActive(false);
            highPullTrigger.SetActive(false);
            pushupTrigger.SetActive(false);
            bicepCurlTrigger.SetActive(false);
            frontRaiseTrigger.SetActive(false);
            pistolSquatTrigger.SetActive(false);
            
        }
    }
}
