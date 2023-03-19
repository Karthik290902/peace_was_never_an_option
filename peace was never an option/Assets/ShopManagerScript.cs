using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    
    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;



    void Start()
    {
        CoinsTXT.text = "Coins: " + coins.ToString();

        //IDs
        shopItems [1,1] =1;
        shopItems [1,2] =2;
        shopItems [1,3] =3;
        shopItems [1,4] =4;

        //Price
        shopItems [2,1] =5;
        shopItems [2,2] =5;
        shopItems [2,3] =5;
        shopItems [2,4] =5;


        //Purchased
        shopItems [3,1] =0;
        shopItems [3,2] =0;
        shopItems [3,3] =0;
        shopItems [3,4] =0;


    }

    
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins>= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]){
            if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] == 0){
                coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
                CoinsTXT.text = "Coins: " + coins.ToString();
                ButtonRef.GetComponent<ButtonInfo>().PurchasedTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }
            
        }

    }
}