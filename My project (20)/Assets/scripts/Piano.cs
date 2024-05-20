using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public bool PianoIsActive;
    public GameObject PianoCam;
    public AudioSource C;
    public AudioSource Cs;
    public AudioSource D;
    public AudioSource Ds;
    public AudioSource E;
    public AudioSource F;
    public AudioSource Fs;
    public AudioSource G;
    public AudioSource Gs;
    public AudioSource A;
    public AudioSource Bb;
    public AudioSource B;
    public AudioSource C1;
    public AudioSource C1s;
    public AudioSource D1;
    public AudioSource D1s;
    public AudioSource E1;
    public AudioSource F1;

    public string Notes="";

    public GameObject Mirror;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(PianoIsActive)
        {
 if(Input.GetKeyDown(KeyCode.A))
 {
    C.Play();
                Notes += "A";
 }     
  if(Input.GetKeyDown(KeyCode.W))
 {
    Cs.Play();
                Notes += "W";
            }   
   if(Input.GetKeyDown(KeyCode.S))
 {
    D.Play();
                Notes += "S";
            } 
   if(Input.GetKeyDown(KeyCode.E))
 {
    Ds.Play();
                Notes += "E";
            } 
   if(Input.GetKeyDown(KeyCode.D))
 {
    E.Play();
                Notes += "D";
            } 
   if(Input.GetKeyDown(KeyCode.F))
 {
    F.Play();
                Notes += "F";
            } 
   if(Input.GetKeyDown(KeyCode.T))
 {
    Fs.Play();
                Notes += "T";
            } 
   if(Input.GetKeyDown(KeyCode.G))
 {
    G.Play();
                Notes += "G";
            } 
   if(Input.GetKeyDown(KeyCode.Y))
 {
    Gs.Play();
                Notes += "Y";
            } 
   if(Input.GetKeyDown(KeyCode.H))
 {
    A.Play();
                Notes += "H";
            } 
   if(Input.GetKeyDown(KeyCode.U))
 {
    Bb.Play();
                Notes += "U";
            } 
   if(Input.GetKeyDown(KeyCode.J))
 {
    B.Play();
                Notes += "J";
            } 
   if(Input.GetKeyDown(KeyCode.K))
 {
    C1.Play();
                Notes += "K";
            } 
   if(Input.GetKeyDown(KeyCode.O))
 {
    C1s.Play();
                Notes += "O";
            } 
   if(Input.GetKeyDown(KeyCode.L))
 {
    D1.Play();
                Notes += "L";
            } 
   if(Input.GetKeyDown(KeyCode.P))
 {
    D1s.Play();
                Notes += "P";
            } 
   if(Input.GetKeyDown(KeyCode.Semicolon))
 {
    E1.Play();
                Notes += ";";
            }
   if(Input.GetKeyDown(KeyCode.Quote))
 {
    F1.Play();
                Notes += "'";
            }  
 PianoCam.SetActive(true);
        }

        else
        {
            PianoCam.SetActive(false);
            if (Notes == "TSSDFDSWSDTJ")
            {
                Mirror.SetActive(true);
                player.SetActive(true);
                Notes = "";
            }
            else
            {
                Notes = "";
            }
        }
            }


        
    }

