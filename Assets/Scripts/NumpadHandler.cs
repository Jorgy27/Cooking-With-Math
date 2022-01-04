using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class NumpadHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject numHead;
    private string numInput="";

    public float numValue = 0;

    public void OnClickNumber(GameObject button)
    {
        string inputText = button.GetComponentInChildren<Text>().text;
        string oldText = numHead.GetComponent<Text>().text;

        if (!inputText.Equals("Επιβεβαίωση"))
        {
            if (inputText.Equals("C") && oldText.Length != 0)
            {
                string newText = oldText.Remove(oldText.Length - 1);
                numInput = newText;
            }
            else if (!inputText.Equals("C"))
            {
                numInput = numHead.GetComponent<Text>().text + inputText;
               
            }

            numHead.GetComponent<Text>().text = numInput;
        }
        else
        {
            //set the value of the amount chosen
            numValue = float.Parse(numInput);
            passValueToBowl(numValue);
            
        }
        
    }

    private void passValueToBowl(float numValue)
    {
        int lastItemUsed = BowlHandler.itemsUsed.Count - 1; //get the index of the last item used
        //creates the item that will update the values{itemAmount,itemAmountLabel} of the list itemsUsed
        Items updateItem = BowlHandler.itemsUsed[lastItemUsed];
        updateItem.itemAmount = numValue;
        updateItem.itemAmountLabel = numInput;
        //update the list item. It was originaly holding only the name of the item, now it has both the values
        BowlHandler.itemsUsed[lastItemUsed] = updateItem;

        //reset the numpad values and turn the ui off
        numValue = 0;
        numInput = "";
        numHead.GetComponent<Text>().text = numInput;
        this.gameObject.SetActive(false);
    }
}
