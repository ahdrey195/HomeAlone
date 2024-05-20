using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource Audio;
    public Transform player;
    public float StartingVolume;
    void Awake()
    {
        AudioSource Audio = gameObject.GetComponent<AudioSource>();
        StartingVolume = Audio.volume;
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 60f))
        {
            if (hit.collider.tag != "Player")
            {
                Audio.volume = StartingVolume/2;
            }
            else 
            {
                Audio.volume = StartingVolume;
            }
        }
    }
}