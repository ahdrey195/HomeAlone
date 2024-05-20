using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildberries : MonoBehaviour
{
    public GameObject Bought;
    public Transform DelieverTo;
    public AudioSource Door;
public void Deliever()
    {
        Invoke("Work", 2);
    }
    void Work()
    {
        Door.Play();
        Instantiate(Bought, DelieverTo.position, Quaternion.identity);
    }
}
