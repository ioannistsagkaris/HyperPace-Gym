using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
   public int[,] shopItems = new int[9,9];
   public float coins;
   public TextMeshProUGUI CoinsTXT;

    void Start() {
        
        CoinsTXT.text = "Funds:" + coins.ToString();

        //ID
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;
        shopItems[1,5] = 5;
        shopItems[1,6] = 6;
        shopItems[1,7] = 7;
        shopItems[1,8] = 8;

        //Price
        shopItems[2,1] = 140;
        shopItems[2,2] = 60;
        shopItems[2,3] = 120;
        shopItems[2,4] = 999;
        shopItems[2,5] = 25;
        shopItems[2,6] = 80;
        shopItems[2,7] = 15;
        shopItems[2,8] = 55;
        
        //Quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
        shopItems[3,5] = 0;
        shopItems[3,6] = 0;
        shopItems[3,7] = 0;
        shopItems[3,8] = 0;
       
        
    }

    public void Buy() {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if(coins >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID]) {

            coins -= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Funds:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        
        }
        
    }
}
