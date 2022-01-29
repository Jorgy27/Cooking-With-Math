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
        //If there are less or more than one finger touching don't do anything
        if (Input.touchCount != 1) 
        {
            return;
        }
        //Get the position of the first touch
        Touch touch = Input.touches[0];
        Vector3 positionOfTouch = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            rayHitInfo = new RaycastHit();
            Ray ray = camera.ScreenPointToRay(positionOfTouch);
            if (Physics.Raycast(ray, out rayHitInfo) && rayHitInfo.collider.name == "superMarket")
            {
                ShopPanel.SetActive(true);
                rayHitInfo.collider.enabled = false; //Disable the shop collider after it is opened
            }
        }
    }
}



