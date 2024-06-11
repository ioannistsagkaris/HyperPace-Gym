using TMPro;
using UnityEngine;

public class TimeCounterScript : MonoBehaviour
{
    private float timer = 300.0f;
    public TMP_Text timerText;

    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();
    }
}
