using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paper : MonoBehaviour
{
public bool Original=false;
public Texture NoImage;
public GameObject paperObject;
    public RawImage image;
    public Rigidbody RB;
    public bool ReadyToPrint=true;
    bool tried=false;
    public Transform originPos;
public void Update()
{
    if(gameObject.name!="paper")
    {
        Original=false;
        gameObject.name="HoldPos1";
    //falshivka
    }
   if(image.texture!=NoImage&&Original==true)
   {
    Invoke("Print",1);
   }
   if(Original==false)
   {

    if(tried==false){
    RB.isKinematic = false;
    gameObject.transform.position=originPos.position;
    tried=true;
    }}
    if (RB.velocity.y>0.1)
    {
        RB.velocity=new Vector3(RB.velocity.x, 0, RB.velocity.z);
    }
}
void Print()
{
if (ReadyToPrint)
{
Instantiate(paperObject);
image.texture=NoImage;
ReadyToPrint=false;
Invoke("PrintReady",1);
}

}
void PrintReady()
{
    ReadyToPrint=true;
}
}
