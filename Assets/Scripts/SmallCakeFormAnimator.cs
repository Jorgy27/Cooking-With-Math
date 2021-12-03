using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCakeFormAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject formContent;

    private void OnTriggerEnter(Collider other)
    {

        animateForm();

    }

    private void animateForm()
    {
        formContent.transform.localScale = new Vector3(40, 40, 40);
    }
}
