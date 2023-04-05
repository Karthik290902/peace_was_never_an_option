using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
    
    public int[,] shopItems = new int[5,5];

    public Text CoinsTXT;
    public int coins;
    public string PurchasedKey;

    Dictionary<int, int> purchasedItems = new Dictionary<int, int>();

    void Start()
    {
        // Load the purchased values of each item from player preferences into the dictionary
        for (int i = 1; i < shopItems.GetLength(1); i++)
        {
            string key = "shopItem_" + i;
            int purchasedValue = PlayerPrefs.GetInt(key);
            purchasedItems.Add(i, purchasedValue);
        }

        coins = PlayerPrefs.GetInt("coins");

        //IDs
        shopItems [1,1] =1;
        shopItems [1,2] =2;
        shopItems [1,3] =3;
        shopItems [1,4] =4;

        //Price
        shopItems [2,1] =20;
        shopItems [2,2] =50;
        shopItems [2,3] =100;
        shopItems [2,4] =0;


        //Purchased
        shopItems [3,1] =0;
        shopItems [3,2] =0;
        shopItems [3,3] =0;
        shopItems [3,4] =0;

    }


    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        int itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;
        int itemPrice = shopItems[2, itemID];

        // Check if the player has enough coins to buy the item
        if (coins >= itemPrice)
        {
            // Check if the item has not been purchased before
            if (!purchasedItems.ContainsKey(itemID) || purchasedItems[itemID] == 0)
            {
                coins -= itemPrice;
                CoinsTXT.text = "Coins: " + coins.ToString();
                purchasedItems[itemID] = 1; // Mark the item as purchased
                PlayerPrefs.SetInt("coins", coins); // Save the updated coin balance

                // Save the purchased value of the item to player preferences
                PlayerPrefs.SetInt("shopItem_" + itemID, 1);
            }
        }
    }


    //to move back to main screen
    public void Back()
    {
        Debug.Log("checking");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}

