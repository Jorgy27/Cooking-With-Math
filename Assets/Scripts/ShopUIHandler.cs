using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShopUIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject ShopPanel;
    [SerializeField]
    private Camera camera;

    private RaycastHit rayHitInfo;

    void FixedUpdate()
    {
        OpenShop();
    }
    

    private void OpenShop()
    {
        if (Input.touchCount != 1) //If there are less or more than one finger touching don't do anything
        {
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
            if (Physics.Raycast(ray, out rayHitInfo) && rayHitInfo.collider.name == "superMarket") //And check if the object hit has the appropriate Tag
            {
                ShopPanel.SetActive(true);
            }
        }
    }
}



