using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class NumpadHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject numHead;
    private string numValue="";

    public static float itemAmount = 0;

    public void OnClickNumber(GameObject button)
    {
        string inputText = button.GetComponentInChildren<Text>().text;
        string oldText = numHead.GetComponent<Text>().text;

        if (!inputText.Equals("Επιβεβαίωση"))
        {
            if (inputText.Equals("Δ") && oldText.Length != 0)
            {
                string newText = oldText.Remove(oldText.Length - 1);
                numValue = newText;
            }
            else if (!inputText.Equals("Δ"))
            {
                numValue = numHead.GetComponent<Text>().text + inputText;
            }

            numHead.GetComponent<Text>().text = numValue;
        }
        else
        {   
            //reset the numpad values and turn the ui off
            itemAmount = float.Parse(numValue);
            Debug.Log(itemAmount);
            itemAmount = 0;
            numValue = "";
            numHead.GetComponent<Text>().text = numValue;
            this.gameObject.SetActive(false);
        }
        
    }
}
