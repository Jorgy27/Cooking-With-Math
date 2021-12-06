using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateCakeAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject SidesOfPan;
    [SerializeField]
    private GameObject BottomOfPan;
    [SerializeField]
    private GameObject CakeDough;
    [SerializeField]
    private GameObject Butter;
    [SerializeField]
    private GameObject CookingBowl;


    private int numberOfCollisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        SidesOfPan.SetActive(false);
        BottomOfPan.SetActive(false);
        CakeDough.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        numberOfCollisions += 1;
        if (numberOfCollisions == 1)
        {
            SidesOfPan.SetActive(true);
            other.GetComponent<Collider>().isTrigger = true;

        }else if (numberOfCollisions == 2)
        {
            BottomOfPan.SetActive(true);
            Butter.SetActive(false);
            CookingBowl.SetActive(true);

        }
        else if (numberOfCollisions == 3)
        {
            CakeDough.SetActive(true);
            CookingBowl.SetActive(false);
        }

    }
}
