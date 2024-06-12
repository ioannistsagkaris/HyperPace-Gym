using TMPro;
using UnityEngine;

public class ButtonInfoScript : MonoBehaviour
{

    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;
    
    public int ItemID;

    void Update() {
        PriceTxt.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2,ItemID].ToString() + "$";
        QuantityTxt.text = "x" + ShopManager.GetComponent<ShopManagerScript>().shopItems[3,ItemID].ToString();
    }
}
