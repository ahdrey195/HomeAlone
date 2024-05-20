using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.transform.Translate(-0.3f,0,0);
}
}
    