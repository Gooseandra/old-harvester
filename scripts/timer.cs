using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timer : MonoBehaviour
{
    [SerializeField] float time;
    TimeSpan ts;
    [SerializeField] Text timerTxt;
    bool go = true;

    void FixedUpdate()
    {
        if (go)
        {
            time -= Time.deltaTime;
            ts = TimeSpan.FromSeconds(time);
            if(ts.Seconds < 10)
            {
                timerTxt.text = ts.Minutes.ToString() + ":0" + ts.Seconds.ToString();
            }
            else
            {
                timerTxt.text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            }

            if (time <= 0)
            {
                go = false;
                GetComponent<pick_up_plants>().endGame("Time out!");
            }
        }
    }
}
