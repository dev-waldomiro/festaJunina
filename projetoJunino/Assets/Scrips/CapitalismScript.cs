using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalismScript : MonoBehaviour
{
    //variaveis
    public int price_1 = 0;
    public int price_2 = 0;
    public int price_3 = 0;


    private bool buying = false;
    public bool Buying 
    {
        get { return buying; }
        set { buying = value; }
    }

    //referencias
    private ShopScript shopScript;
    private GameManagerScript gameManager;
    public GameObject product1;
    public GameObject product2;
    public GameObject product3;
    private InventoryScript inventory;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        shopScript = GetComponent<ShopScript>();
        inventory = GameObject.Find("Inventory").GetComponent<InventoryScript>();
    }

    void Update()
    {
        if(price_1 != 0f || price_2 != 0f || price_3 != 0f) 
            shopScript.money = true;
        else shopScript.money = false;


        if(shopScript.money)
        {
            if(Input.GetKeyDown(KeyCode.Z) && price_1 <= gameManager.Coins) 
                Buy(1);
            if(Input.GetKeyDown(KeyCode.X) && price_2 <= gameManager.Coins)
                Buy(2);
            if(Input.GetKeyDown(KeyCode.C) && price_3 <= gameManager.Coins)
                Buy(3);
        }
    }

    void Buy (int ItemID)
    {
        int aux = gameManager.Coins;
        switch (ItemID)
        {
            case 1:
                price_1 = 0;
                inventory.AddItem(product1);
                gameManager.Coins = aux - price_1;
                Debug.Log("Item 1 bought.");
                break;
            case 2:
                price_2 = 0;
                inventory.AddItem(product2);
                gameManager.Coins = aux - price_2;
                Debug.Log("Item 2 bought.");
                break;
            case 3:
                price_3 = 0;
                inventory.AddItem(product3);
                gameManager.Coins = aux - price_3;
                Debug.Log("Item 3 bought.");
                break;
            default:
                Debug.Log("The script wants to buy an inexistent item.");
                break;

        }
    }
}
