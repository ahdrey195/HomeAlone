using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class Saving : MonoBehaviour
{
    public bool EndingSleep;
    public bool EndingNoSleep;
    public bool EndingBackrooms;
    public bool EndingSecret;

    public int EndingSleepInt;
    public int EndingNoSleepInt;
    public int EndingBackroomsInt;
    public int EndingSecretInt;

    public GameObject Cheats;

    void Awake()
    {
        if (PlayerPrefs.HasKey("EndingSleep"))
        {
            if (PlayerPrefs.GetInt("EndingSleep") == 1) 
            {
                EndingSleep = true;
                EndingSleepInt = 1;
            }
            else
            {
                EndingSleep = false;
            }
        }
        if (PlayerPrefs.HasKey("EndingNoSleep"))
        {

            if (PlayerPrefs.GetInt("EndingNoSleep") == 1)
            {
                EndingNoSleep = true;
                EndingNoSleepInt = 1;
            }
            else
            {
                EndingNoSleep = false;
            }
        }
        if (PlayerPrefs.HasKey("EndingBackrooms"))
        {

            if (PlayerPrefs.GetInt("EndingBackrooms") == 1)
            {
                EndingBackrooms = true;
                EndingBackroomsInt = 1;
            }
            else
            {
                EndingBackrooms = false;
            }
        }
        if (PlayerPrefs.HasKey("EndingSecret"))
        {
            if (PlayerPrefs.GetInt("EndingSecret") == 1)
            {
                EndingSecret = true;
                EndingSecretInt = 1;
            }
            else
            {
                EndingSecret = false;
            }
        }
            if (PlayerPrefs.HasKey("Cheats"))
            {
                if (PlayerPrefs.GetInt("Cheats") == 1)
                {
                Cheats.SetActive(true);
                }
            }
        

    }
    public void Save()
    {
        PlayerPrefs.SetInt("EndingSleep", EndingSleepInt);
        PlayerPrefs.SetInt("EndingNoSleep", EndingNoSleepInt);
        PlayerPrefs.SetInt("EndingBackrooms", EndingBackroomsInt);
        PlayerPrefs.SetInt("EndingSecret", EndingSecretInt);

    }
}
