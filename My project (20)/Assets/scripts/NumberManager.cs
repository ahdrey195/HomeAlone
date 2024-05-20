using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberManager : MonoBehaviour
{ 
    public bool active = false;
    public string number = "";
    public TMP_Text numberInput;
    public GameObject call;
    bool calling;
    public GameObject erase;
    public AudioSource ring;
    public AudioSource ringFail;
    public AudioSource Pizza;
    public interaction Player;
    public GameObject FailText;
    public GameObject PizzaDelievery;
    public AudioSource DoorBell;

    void Update()
    {
        if (active == true && calling == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Number1();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Number2();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Number3();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Number4();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Number5();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Number6();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Number7();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                Number8();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                Number9();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Number0();
            }


            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                NumberBackspace();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Call();
            }
            if (number.Length >= 1)
            {
                erase.SetActive(true);
            }
            numberInput.text = number;
        }
    }
    public void Activate()
    {
        active = true;
    }
    public void Deactivate()
    {
        active = false;
        number = "";
    }
    public void Number1()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "1";
        }
    }
    public void Number2()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "2";
        }
    }
    public void Number3()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "3";
        }
    }
    public void Number4()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "4";
        }
    }
    public void Number5()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "5";
        }
    }
    public void Number6()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "6";
        }
    }
    public void Number7()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "7";
        }
    }
    public void Number8()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "8";
        }
    }
    public void Number9()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "9";
        }
    }
    public void Number0()
    {
        if (number.Length < 11 && calling == false)
        {
            number += "0";
        }
    }
    public void NumberBackspace()
    {
        if (calling == false&& number.Length>=1)
        {
            number = number.Substring(0, number.Length - 1);
        }
    }
    public void Call()

    {
        if (number.Length >= 1)
        {
            call.SetActive(true);
            ring.Play();
            if (number == "87783302389")
            {
                Invoke("PizzaCall", 3f);
            }
            else
            {
                Invoke("RingEnd", 3);
            }
        }
    }
    void PizzaCall()
    {
        ring.Stop();
        Pizza.Play();
        Invoke("PizzaDelivery", Random.Range(10, 20));
        Invoke("RingEndPizza", 4);
    }
    void RingEndPizza()
    {
        Pizza.Stop();
        call.SetActive(false);
        number = "";
    }
    public void PizzaDelivery()
    {
        PizzaDelievery.SetActive(true);
        DoorBell.Play();
    }
    void RingEnd()
    {
        ringFail.Play();
        ring.Stop();
        Invoke("RemovePhone", 3);
        FailText.SetActive(true);
    }
    void RemovePhone()
    {
        FailText.SetActive(false);
        call.SetActive(false);
        number = "";
    }
}