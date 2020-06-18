using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public bool money = false;
    private GameObject itensList;
    private SpriteRenderer sr;

    void Awake()
    {
        itensList = transform.Find("ItensList").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && money == true)
        {
            itensList.SetActive(true);
        } else {
            itensList.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        itensList.SetActive(false);
    }
}
