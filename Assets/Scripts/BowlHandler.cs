using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BowlHandler : MonoBehaviour
{
   
    [SerializeField]
    private GameObject amountUI;

    private int collisionCounter;
    private int numberOfMaterials;

    public static List<Items> itemsUsed = new List<Items>();

    private void Start()
    {
        numberOfMaterials = GameObject.FindGameObjectsWithTag("CookingMaterial").Length;
    }


    private void OnTriggerEnter(Collider other)
    {
        ActivateUI();

        collisionCounter += 1;
        //limits how many materials can be used to fill the bowl
        if (collisionCounter <= numberOfMaterials)
        {
            string itemNameCol = other.name;
            
            var newItemAdded = new Items(itemNameCol, 0, "");
            itemsUsed.Add(newItemAdded);

        }
        
    }

    private void ActivateUI()
    {
        amountUI.SetActive(true);
    }
}
