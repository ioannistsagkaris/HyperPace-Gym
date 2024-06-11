using TMPro;
using UnityEngine;

public class RepCounterScript : MonoBehaviour
{
    public int repCounter = 0;
    public TMP_Text repText;

    public void addRep() {
        repCounter++;
        repText.text = "Reps: " + repCounter.ToString();
    }
}
