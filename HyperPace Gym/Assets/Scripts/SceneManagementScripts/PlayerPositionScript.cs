using UnityEngine;

public class PlayerPositionScript : MonoBehaviour
{
    public Transform playerPosition;

    void Start() {
       LoadPlayerPosition();
    }

    public void SavePlayerPosition(float x, float y, float z) {
        PlayerPrefs.SetFloat("position.x", x);
        PlayerPrefs.SetFloat("position.y", y);
        PlayerPrefs.SetFloat("position.z", z);
    }

    public void LoadPlayerPosition() {
        float x = PlayerPrefs.GetFloat("position.x");
        float y = PlayerPrefs.GetFloat("position.y");
        float z = PlayerPrefs.GetFloat("position.z");

        if (x == 0 && y == 0 && z == 0) {
            playerPosition.position = new Vector3((float)-11.71, (float)3.853, (float)6.7);
            return;
        }
        
        playerPosition.position = new Vector3(x, y, z);
    }
}
