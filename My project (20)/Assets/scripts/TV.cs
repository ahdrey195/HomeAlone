using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class TV : MonoBehaviour
{
    public GameObject TVScreen;
    public Rigidbody TVRemote;
    public int ChannelNumber=1;
    public int Volume;
    public Sound TvAudioPlayer;

    public VideoPlayer Tv1;
    public VideoPlayer Tv2;
    public VideoPlayer Tv3;
    public VideoPlayer Tv4;
    public VideoPlayer Tv5;
    public VideoPlayer Tv6;
    public VideoPlayer Tv7;
    public VideoPlayer Tv8;
    public VideoPlayer Tv9;
    public VideoPlayer Tv10;

    public GameObject GO1;
    public GameObject GO2;
    public GameObject GO3;
    public GameObject GO4;
    public GameObject GO5;
    public GameObject GO6;
    public GameObject GO7;
    public GameObject GO8;
    public GameObject GO9;
    public GameObject GO10;

    public TMP_Text VolumeText;
    public GameObject VolumeDecail;
    public TMP_Text ChannelNumberText;
    public GameObject Controls;
    void Start()
    {
        
    }

    void Update()
    {
        if (TVScreen.activeSelf&&TVRemote.isKinematic == true)
        { 
            if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.V))
            {
                if (ChannelNumber > 1)
                {
                    ChannelNumber = ChannelNumber - 1;
                }
                else
                {
                    ChannelNumber = 10;
                }
                ShowChannel();
            }
            else if (Input.GetButtonDown("Fire2") && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.V))
            {
                if (ChannelNumber < 10)
                {
                    ChannelNumber = ChannelNumber + 1;
                }
                else
                {
                    ChannelNumber = 1;
                }
                ShowChannel();
            }

            else if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.V))
            {
             
            }
            else if (Input.GetButtonDown("Fire2") && Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.V))
            {

            }

            else if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.V))
            {
                if (Volume > 1)
                {
                    Volume -= 1;
                }
                ShowVolume();
            }
            else if (Input.GetButtonDown("Fire2") && !Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.V))
            {
                if (Volume < 10)
                {
                    Volume += 1;
                }
                ShowVolume();
            }
        }
        TvAudioPlayer.StartingVolume=Volume*0.01f;
        if (Time.timeScale == 1)
        {
            switch (ChannelNumber)
            {
                case 1:
                    Tv1.Play();
                    Tv2.Pause();
                    Tv10.Pause();
                    GO1.SetActive(true);
                    GO2.SetActive(false);
                    GO10.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv1.time = Tv1.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv1.playbackSpeed >= 2)
                        {
                            Tv1.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv1.playbackSpeed = Tv1.playbackSpeed * 2;
                    }
                    break;
                case 2:
                    Tv2.Play();
                    Tv1.Pause();
                    Tv3.Pause();
                    GO2.SetActive(true);
                    GO1.SetActive(false);
                    GO3.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv2.time = Tv2.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv2.playbackSpeed >= 2)
                        {
                            Tv2.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv2.playbackSpeed = Tv2.playbackSpeed * 2;
                    }
                    break;
                case 3:
                    Tv3.Play();
                    Tv2.Pause();
                    Tv4.Pause();
                    GO3.SetActive(true);
                    GO4.SetActive(false);
                    GO2.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv3.time = Tv3.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv3.playbackSpeed >= 2)
                        {
                            Tv3.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv3.playbackSpeed = Tv3.playbackSpeed * 2;
                    }
                    break;
                case 4:
                    Tv4.Play();
                    Tv5.Pause();
                    Tv3.Pause();
                    GO4.SetActive(true);
                    GO5.SetActive(false);
                    GO3.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv4.time = Tv4.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv4.playbackSpeed >= 2)
                        {
                            Tv4.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv4.playbackSpeed = Tv4.playbackSpeed * 2;
                    }
                    break;
                case 5:
                    Tv5.Play();
                    Tv6.Pause();
                    Tv4.Pause();
                    GO5.SetActive(true);
                    GO6.SetActive(false);
                    GO4.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv5.time = Tv5.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv5.playbackSpeed >= 2)
                        {
                            Tv5.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv5.playbackSpeed = Tv5.playbackSpeed * 2;
                    }
                    break;
                case 6:
                    Tv6.Play();
                    Tv5.Pause();
                    Tv7.Pause();
                    GO6.SetActive(true);
                    GO5.SetActive(false);
                    GO7.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv6.time = Tv6.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv6.playbackSpeed >= 2)
                        {
                            Tv6.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv6.playbackSpeed = Tv6.playbackSpeed * 2;
                    }
                    break;
                case 7:
                    Tv7.Play();
                    Tv8.Pause();
                    Tv6.Pause();
                    GO7.SetActive(true);
                    GO8.SetActive(false);
                    GO6.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv7.time = Tv7.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv7.playbackSpeed >= 2)
                        {
                            Tv7.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv7.playbackSpeed = Tv7.playbackSpeed * 2;
                    }
                    break;
                case 8:
                    Tv8.Play();
                    Tv9.Pause();
                    Tv7.Pause();
                    GO8.SetActive(true);
                    GO9.SetActive(false);
                    GO7.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {

                        Tv8.time = Tv8.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv8.playbackSpeed >= 2)
                        {
                            Tv8.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv8.playbackSpeed = Tv8.playbackSpeed * 2;
                    }
                    break;
                case 9:
                    Tv9.Play();
                    Tv10.Pause();
                    Tv8.Pause();
                    GO9.SetActive(true);
                    GO8.SetActive(false);
                    GO10.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {
                        Tv9.time = Tv9.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv9.playbackSpeed >= 2)
                        {
                            Tv9.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv9.playbackSpeed = Tv9.playbackSpeed * 2;
                    }
                    break;
                case 10:
                    Tv10.Play();
                    Tv1.Pause();
                    Tv9.Pause();
                    GO10.SetActive(true);
                    GO1.SetActive(false);
                    GO9.SetActive(false);
                    if (Input.GetKey(KeyCode.C) && Input.GetButton("Fire1"))
                    {
                        Tv10.time = Tv10.time - 1;
                    }
                    if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire1"))
                    {
                        if (Tv10.playbackSpeed >= 2)
                        {
                            Tv10.playbackSpeed = 1;
                        }
                    }

                    else if (Input.GetKey(KeyCode.C) && Input.GetButtonDown("Fire2"))
                    {
                        Tv10.playbackSpeed = Tv10.playbackSpeed * 2;
                    }
                    break;
            }
        }
        else
        {
            Tv1.Pause();
            Tv2.Pause();
            Tv3.Pause();
            Tv4.Pause();
            Tv5.Pause();
            Tv6.Pause();
            Tv7.Pause();
            Tv8.Pause();
            Tv9.Pause();
            Tv10.Pause();
        }
    }
    void GoBack()
    {

    }
    void GoForward()
    {

    }
    void ShowVolume()
    {
        VolumeText.text = Volume.ToString();
        VolumeDecail.SetActive(true);
        Invoke("HideVolume", 3f);
    }
    void ShowChannel()
    {
        ChannelNumberText.text = ChannelNumber.ToString();
        Invoke("HideChannel", 3f);
    }
    void HideVolume()
    {
        VolumeText.text = "";
        VolumeDecail.SetActive(false);
    }
    void HideChannel()
    {
        ChannelNumberText.text = "";
    }
    public void PickedUp()
    {
        Controls.SetActive(true);
        Invoke("ControllsOff", 3);
    }
    void ControllsOff()
    { 
    Controls.SetActive(false);
    }


}
