using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BowlHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject bowlContent;
    [SerializeField]
    private GameObject amountUI;

    private Vector3 scaleChange, positionChange;
    private Vector3 originalScale, originalPosition;
    private int collisionCounter;
    private int numberOfMaterials;

    public static List<Items> itemsUsed = new List<Items>();

    private void Start()
    {
        originalScale = bowlContent.transform.localScale;
        originalPosition = bowlContent.transform.position;

        collisionCounter = 0;
        bowlContent.transform.position = new Vector3(0, 0, 0);
        bowlContent.transform.localScale = new Vector3(0, 0, 0);
        numberOfMaterials = GameObject.FindGameObjectsWithTag("CookingMaterial").Length;

        float scaleCalc = originalScale.x / numberOfMaterials;
        float positionCalc = originalPosition.y / numberOfMaterials;

        scaleChange = new Vector3(scaleCalc, scaleCalc, scaleCalc);
        positionChange = new Vector3(0, positionCalc, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateUI();

        collisionCounter += 1;
        //limits how many materials can be used to fill the bowl
        if (collisionCounter <= numberOfMaterials)
        {
            bowlContent.transform.localScale += scaleChange;
            bowlContent.transform.position += positionChange;
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
