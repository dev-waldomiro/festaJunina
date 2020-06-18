using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private int numberOfItensCollected;
    public int numberOfItens;
    private List<GameObject> inventory = new List<GameObject>();


    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        numberOfItensCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfItens == numberOfItensCollected) Debug.Log("You have won the game.");
    }

    public void AddItem(GameObject item)
    {
        bool itemFound = false;
        if(numberOfItensCollected != 0)
        {
            foreach(GameObject itemOwned in inventory)
            {
                if(itemOwned == item)
                    itemFound = true;
            }
            if(!itemFound)
            {
                inventory.Add(item);
                numberOfItensCollected++;
            } else
            {
                Debug.Log("This item is already in the players inventory.");
            }
        } else 
        {
            inventory.Add(item);
            numberOfItensCollected++;
        }
    }
}
