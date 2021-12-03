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
    private GameObject FailedTaskPanel;
    [SerializeField]
    private GameObject QuestionnairePanel;

    private double sumPrice =0.0;
    private int itemAmount;

    [NonSerialized]
    public double amountLeft=0.0;

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

        if (sumPrice > money || sumPrice==0)
        {
            FailedTaskPanel.SetActive(true);
        }
        else
        {
            amountLeft = money - sumPrice;
            QuestionnairePanel.SetActive(true);
        }
    }
}
