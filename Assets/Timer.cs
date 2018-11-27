using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject timer;

    private float time_passed = 0;
    private int minutes = 0;
    private int tens_secs = 0;
    private int seconds = 0;

    private string display_time = "0:00";

	// Update is called once per frame
	void Update ()
    {
        time_passed += Time.deltaTime;

        if(time_passed > 9.9f)
        {
            tens_secs++;
            time_passed = 0;
            seconds = 0;
        }
        if(tens_secs > 5)
        {
            minutes++;
            tens_secs = 0;
            seconds = 0;
        }

        seconds = Mathf.RoundToInt(time_passed);

        display_time = minutes + ":" + tens_secs + seconds;

        timer.GetComponent<Text>().text = display_time;
	}
}
