using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIHandler : MonoBehaviour
{
    private Text textOfClock;

    private void Awake()
    {
        textOfClock = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);

        textOfClock.text = hour + ": " + minute; 
    }

    public static string LeadingZero(int time)
    {
        //this way the time will always have a length of 2 digits. Example: 1:30 => 01:30
        return time.ToString().PadLeft(2, '0'); 
    }
}
