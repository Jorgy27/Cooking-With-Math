using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCupHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject teaCupContent;

    [SerializeField]
    private float speed =0.5f;
    [SerializeField]
    private Color startColor;
    [SerializeField]
    private Color endColor;

    private float startTime;

    private bool startChangeOfMaterial = false;


    private void Update()
    {
        if (startChangeOfMaterial)
        {
            
            float t = (Time.time - startTime) * speed;
            teaCupContent.GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor,t);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        startChangeOfMaterial = true;
        startTime = Time.time;
    }


}
