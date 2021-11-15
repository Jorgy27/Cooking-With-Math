using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    [SerializeField]
    private string objectTag;
    [SerializeField]
    private Camera camera;

    private Vector3 distance;

    private bool touched = false;
    private bool dragging = false;

    private Transform toDrag;
    private Vector3 newPosition;
    private Vector3 previousPosition;
    private Vector3 originalPosition;

    private RaycastHit rayHitInfo;

    private void FixedUpdate()
    {
        OnTouch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "CookingMaterial")
        {
            dragging = false;
            touched = false;
            toDrag.position = originalPosition;
            this.GetComponent<Collider>().isTrigger = false; //disable the trigger when the material is used
        }
    }

    private void OnTouch()
    {
        if (Input.touchCount != 1) //If there are less or more than one finger touching don't do anything
        {
            dragging = false;
            touched = false;
            return;
        }

        //Get the position of the first touch
        Touch touch = Input.touches[0];
        Vector3 positionOfTouch = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            rayHitInfo = new RaycastHit();
            Ray ray = camera.ScreenPointToRay(positionOfTouch);  //Creates a Ray(line) from the camera to the first position that was touched

            //Returns true if ray collides with any object using {ray} as point of origin and if true {rayHitInfo} contains information about the object hit
            if (Physics.Raycast(ray, out rayHitInfo) && rayHitInfo.collider.CompareTag(objectTag)) //And check if the object hit has the appropriate Tag
            {
                toDrag = rayHitInfo.transform; //Get the transform of the object that was touched
                previousPosition = toDrag.position;
                originalPosition = previousPosition;

                distance = camera.WorldToScreenPoint(previousPosition); // Save the screen location and depth of the object that was touched (Vector3)
                newPosition = new Vector3(distance.x, distance.y, distance.z);

                touched = true;
            }
        }

        if (touched && touch.phase == TouchPhase.Moved)
        {
            dragging = true;

            float newPosX = Input.GetTouch(0).position.x;
            float newPosY = Input.GetTouch(0).position.y;
            Vector3 currentPosition = new Vector3(newPosX, newPosY, distance.z); //Get the new position with each movement

            Vector3 worldPosition = camera.ScreenToWorldPoint(currentPosition); //Make movement relative to the world
            worldPosition = new Vector3(worldPosition.x, 0.0f, worldPosition.z); //remove the z movement

            previousPosition = toDrag.position; //save the current position as the last known position before changing it
            toDrag.position = worldPosition; //change the position of the object to the new world position
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
            touched = false;

            previousPosition = new Vector3();
            toDrag.position = originalPosition;
        }
    }

}
