using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = "Price: " + ShopManager.GetComponent<ShopManager>().shopItems[2,ItemID].ToString() + "$";
        QuantityTxt.text = "x" + ShopManager.GetComponent<ShopManager>().shopItems[3,ItemID].ToString();
    }
}
