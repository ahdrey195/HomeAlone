using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LIghts : MonoBehaviour
{
    public int Time;
    public float TimeScale=1;
public Light Kitchen1;
public Light Kitchen2;

public bool TimeStop;
public Light Main1;
public Light Main2;

public TMP_Text Phone;
    public TMP_Text PhoneMini;
    public TMP_Text PC;

    public GameObject Car;

    public interaction Player;
    int RandomCar;

    int Hungury;

    public bool ChangeTime=false;

    public Transform VirtualCamera1;
    public Transform Camera;
    public GameObject VirtualCamera1obj;
    public GameObject VirtualCamera2obj;

    public FirstPersonController fpc;
    public Saving Save;
    public GameObject Ending;
    public bool sleeping=false;

    bool triedHungry = false;

    void Start()
    {
      InvokeRepeating("AddSecond",0, (1f/ TimeScale));
        RandomCar = Random.Range(60, 300);
        Hungury = Random.Range(150, 300);
        if(Random.Range(0,3)==1)
        {
            if (Random.Range(50, 300) == Time)
            {
                ElectricityOff();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Kitchen1.range=(Time-200)*0.25f;
        Kitchen2.range=(Time-200)* 1.25f;
        
        Main1.range=(Time-200)*0.25f;
        Main2.range=(Time-200)* 1.25f;

if ((Time%60)<10)
{
Phone.text=("0"+(Time/60).ToString()+":0"+(Time%60).ToString());
PhoneMini.text = ("0" + (Time / 60).ToString() + ":0" + (Time % 60).ToString());
PC.text = ("0" + (Time / 60).ToString() + ":0" + (Time % 60).ToString());
        }
else
{
Phone.text=("0"+(Time/60).ToString()+":"+(Time%60).ToString());
PhoneMini.text = ("0" + (Time / 60).ToString() + ":" + (Time % 60).ToString());
PC.text = ("0" + (Time / 60).ToString() + ":" + (Time % 60).ToString());
        }
        if (sleeping == false)
        {
            if (Time >= 360)
            {
                TimeStop = true;

                VirtualCamera1.position = Camera.transform.position;
                VirtualCamera1.rotation = Camera.transform.rotation;
                VirtualCamera1obj.SetActive(true);
                fpc.playerCanMove = false;
                fpc.cameraCanMove = false;
                Player.canOpenMenu = false;
                Invoke("PlayerToMenu", 12);
                Invoke("endingActivate", 5);
                Save.EndingNoSleepInt = 1;
                Save.Save();
                Invoke("CameraActive", 0.5f);
            }
        }

        if (Time == RandomCar)
        { 
        Car.SetActive(true);
        }

        if (Time == Hungury)
        {
            if (triedHungry == false)
            {
                triedHungry=true;
                Player.Hungry();

            }
        }
        if (ChangeTime==true)
        {
            ChangeSpeed();
        }
        }
    void AddSecond()
    {
       if (TimeStop==false){
Time+=1;
       }
    }
    void endingActivate()
    {
        Ending.SetActive(true);
    }
    void ElectricityOff()
    {
        Player.electricityOff();
    }
public void ChangeSpeed()
    {
        CancelInvoke("AddSecond");
        InvokeRepeating("AddSecond", 0, (1f / TimeScale));
    }
    void CameraActive()
    {
        VirtualCamera2obj.SetActive(true);
    }
   void PlayerToMenu()
    {
        Player.ToMenu();
    }

    public void TimeStopOn()
    {
        TimeStop = true;
    }
    public void TimeStopOff()
    {
        TimeStop = false;
    }
}
