using UnityEngine;

public class ShopItemSaveLoadScript : MonoBehaviour
{
    public ShopManagerScript shopManager;

    void Start() {
        LoadItemsQuantity();
    }

    public void SaveFunds(float funds) {
        PlayerPrefs.SetFloat("Funds", funds);
    }

    public void SaveItemQuantity(int itemId, int quantity) {

        switch (itemId) {

            case 1:
                PlayerPrefs.SetInt("Protein", quantity);
                break;
            case 2:
                PlayerPrefs.SetInt("Creatine", quantity);
                break;
            case 3:
                PlayerPrefs.SetInt("PreWorkout", quantity);
                break;
            case 4:
                PlayerPrefs.SetInt("Testosterone", quantity);
                break;
            case 5:
                PlayerPrefs.SetInt("Chalk", quantity);
                break;
            case 6:
                PlayerPrefs.SetInt("Belt", quantity);
                break;
            case 7:
                PlayerPrefs.SetInt("Straps", quantity);
                break;
            case 8:
                PlayerPrefs.SetInt("Gloves", quantity);
                break;

        }

    }

    public float LoadFunds() {
        return PlayerPrefs.GetFloat("Funds", 5000);
    }

    public void LoadItemsQuantity() {

        shopManager.shopItems[3, 1] = PlayerPrefs.GetInt("Protein", 0);
        shopManager.shopItems[3, 2] = PlayerPrefs.GetInt("Creatine", 0);
        shopManager.shopItems[3, 3] = PlayerPrefs.GetInt("PreWorkout", 0);
        shopManager.shopItems[3, 4] = PlayerPrefs.GetInt("Testosterone", 0);
        shopManager.shopItems[3, 5] = PlayerPrefs.GetInt("Chalk", 0);
        shopManager.shopItems[3, 6] = PlayerPrefs.GetInt("Belt", 0);
        shopManager.shopItems[3, 7] = PlayerPrefs.GetInt("Straps", 0);
        shopManager.shopItems[3, 8] = PlayerPrefs.GetInt("Gloves", 0);
        
    }
}
