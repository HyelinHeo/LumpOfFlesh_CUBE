using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    public Text timeText;
    public Light lt;

    private float sec = 120.0f;
    private int min;
    private int lightDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (sec <= 0)
        {
            timeText.text = string.Format("GAME OVER");
        }
        else
        {
          //  Debug.Log(sec);
            sec -= Time.deltaTime;
            timeText.text = string.Format("{0:D2}:{1:D2}", ((int)sec / 60).ToString("00"), ((int)(sec % 60)).ToString("00"));

            //if ((int)sec == 100)
            //    lt.intensity = 0.8f;
            //if ((int)sec == 80)
            //    lt.intensity = 0.6f;
            //if ((int)sec == 60)
            //    lt.intensity = 0.4f;
            //if ((int)sec == 40)
            //    lt.intensity = 0.2f;
            //if ((int)sec == 20)
            //    lt.intensity = 0.1f;

        }
    }
}
