using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveMechanic : MonoBehaviour
{
    [Header("Time")]
    public float tick;
    public float seconds;
    public int mins;

    [Header("Wave Counter")]
    public GameObject WaveAnnouncement;
    public TextMeshProUGUI wavecount_text;
    public int wavecount_update;

    // Start is called before the first frame update
    void Start()
    {
        tick = 1f;
        WaveAnnouncement.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalcTime();

        if (mins >= 2) //Next Wave
        {
            NextWave();
            wavecount_update++;
        }

        if (seconds >= 3) //Next Wave Announcement
        {
            WaveAnnouncement.SetActive(false);
        }

        wavecount_text.text = wavecount_update.ToString();
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

    public void NextWave()
    {
        //Time
        WaveAnnouncement.SetActive(true);
        mins = 0;
    }
}
