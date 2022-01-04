using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject bowlContent;

    private Vector3 scaleChange, positionChange;
    private Vector3 originalScale, originalPosition;

    private int numberOfMaterials;
    private int collisionCounter;


    void Start()
    {
        setOriginalPositionOfBowlContent();
        //numberOfMaterials = GameObject.FindGameObjectsWithTag("CookingMaterial").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        collisionCounter += 1;
        //limits how many materials can be used to fill the bowl
        if (collisionCounter <= numberOfMaterials)
        {
            animateBowl();
        }

    }

    private void setOriginalPositionOfBowlContent()
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

    private void animateBowl()
    {
        bowlContent.transform.localScale += scaleChange;
        bowlContent.transform.position += positionChange;
    }
}
