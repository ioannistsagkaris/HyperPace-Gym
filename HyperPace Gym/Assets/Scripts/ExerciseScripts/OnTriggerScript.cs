using UnityEngine;

public class OnTriggerScript : MonoBehaviour
{
    public RepCounterScript repCounter;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == 6)
            repCounter.addRep();
    }
}
