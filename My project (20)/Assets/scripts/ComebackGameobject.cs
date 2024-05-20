using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComebackGameobject : MonoBehaviour
{
    public bool UsingTransform;
    public Transform publicTransform;
    public int comeBackIn=10;
    public bool isInRoom=true;
    public bool isHolding=false;
    public bool wasHeld = false;
    Vector3 StartingPosition;
    public Quaternion StartingRotation;
    Rigidbody rb;
    void Start()
    {
        if (UsingTransform == false)
        {
            StartingPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (isInRoom == false && isHolding == false)
        {
            Comeback();
        }
        if (rb.isKinematic == true)
        {
            isHolding = true;
            wasHeld = true;
        }
        else
        {
            isHolding = false;
        }
        if (wasHeld == true&&isHolding == false)
        {
            Invoke("CheckIsHolding", comeBackIn);
            wasHeld = false;
        }
        else if (wasHeld ==false&&isHolding==true)
        {
            CancelInvoke("CheckIsHolding");
            Invoke("CheckIsHolding", comeBackIn);
            wasHeld = false;
        }
    }
    void Comeback()
    {
        if (UsingTransform == false)
        {
            gameObject.transform.position = StartingPosition;
            gameObject.transform.rotation = StartingRotation;
            rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.position = publicTransform.position;
            gameObject.transform.rotation = publicTransform.rotation;
        }
    }
    void CheckIsHolding()
    {
        if (isHolding==false)
        { 
        Comeback();  
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Home")
        {
            isInRoom = true;
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Home")
        {
            isInRoom = false;
        }
    }

}
