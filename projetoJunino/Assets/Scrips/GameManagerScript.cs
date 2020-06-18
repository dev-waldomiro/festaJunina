using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private int coins = 80;

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
