using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMechanic : MonoBehaviour
{
    [Header("Scripts")]
    public float tick;
    public float seconds;
    public int mins;

    // Start is called before the first frame update
    void Start()
    {
        tick = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalcTime();
    }
    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
            Debug.Log("Next Wave!");
        }
    }
}
