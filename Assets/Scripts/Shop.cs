using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    [SerializeField]
    private double money;
    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private GameObject CompletedTaskPanel;
    [SerializeField]
    private GameObject FailedTaskPanel;

    private double sumPrice =0.0;
    private int itemAmount;

    void Start()
    {
        moneyText.text = "Χρήματα: "+money.ToString() + " €";
        
    }

    public void addItemToBuy(GameObject item)
    {
        itemAmount = int.Parse(item.GetComponentsInChildren<Text>()[1].text) + 1;
        sumPrice += Double.Parse(item.GetComponentsInChildren<Text>()[0].text);

        item.GetComponentsInChildren<Text>()[1].text = itemAmount.ToString();
 
    }

    public void completeShopping()
    {
        //close the shopping panel and activate the corresponding panels
        GameObject.Find("ShopPanel").SetActive(false);
        if (sumPrice > money || sumPrice==0)
        {
            FailedTaskPanel.SetActive(true);
        }
        else
        {
            CompletedTaskPanel.SetActive(true);
            
        }
    }
}
