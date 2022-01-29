using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateCakeHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject Questionnaire;

    private int numberOfCollisions = 0;

    private void OnTriggerEnter(Collider other)
    {
        numberOfCollisions += 1;
        if (numberOfCollisions <= 2)
        {
            Questionnaire.SetActive(true);
        }
        else
        {
            Questionnaire.SetActive(false);
        }
        
    }
}
