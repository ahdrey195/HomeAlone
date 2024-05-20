using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class flip : MonoBehaviour
{
    public GameObject Text;
    public GameObject TextJump;
    public bool timerIsActive = false;
    public float Time;
    public float TimeForShow;
    public TextMeshProUGUI timer;
    public float preveousTime=0;
    public TextMeshProUGUI preveoustimer;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "Finish")
        {
            Text.SetActive(true);
        }
        if (col.gameObject.name == "Finish")
        {
            if (timerIsActive == false)
            {
                InvokeRepeating("TimeAdd", 0, 0.01f);
                TextJump.SetActive(true); 
                Invoke("TextJumpOff", 5);
            }
            else
            {
                preveoustimer.text = TimeForShow.ToString();
                Time = 0;
            }
            timerIsActive = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name != "Finish")
        {
            Text.SetActive(false);
        }
    }
    void TimeAdd()
    {
        Time = Time + 0.01f;
        TimeForShow = Mathf.Round(Time * 100.0f) * 0.01f;

        timer.text = (TimeForShow.ToString());
    }
    void TextJumpOff()
    {
        TextJump.SetActive(false);
    }
}
