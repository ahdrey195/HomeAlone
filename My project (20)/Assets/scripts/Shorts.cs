using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Shorts : MonoBehaviour
{public int RandomNumber;
    public int previousShort;
    public GameObject VideoPlayer1;
public GameObject VideoPlayer2;
public GameObject VideoPlayer3;
public GameObject VideoPlayer4;
    public GameObject VideoPlayer5;
    void Update()
    {
        
    }
   public void PlayVideo()
    {
        Randomize();
switch (RandomNumber)
{
    case 1:
    VideoPlayer1.SetActive(true);
    VideoPlayer2.SetActive(false);
    VideoPlayer3.SetActive(false);
    VideoPlayer4.SetActive(false);
                VideoPlayer5.SetActive(false);
    break;
    case 2:
    VideoPlayer1.SetActive(false);
    VideoPlayer2.SetActive(true);
    VideoPlayer3.SetActive(false);
    VideoPlayer4.SetActive(false);
                VideoPlayer5.SetActive(false);
    break;
    case 3:
    VideoPlayer1.SetActive(false);
    VideoPlayer2.SetActive(false);
    VideoPlayer3.SetActive(true);
    VideoPlayer4.SetActive(false);
                VideoPlayer5.SetActive(false);
    break;
    case 4:
    VideoPlayer1.SetActive(false);
    VideoPlayer2.SetActive(false);
    VideoPlayer3.SetActive(false);
    VideoPlayer4.SetActive(true);
                VideoPlayer5.SetActive(false);
    break;
            case 5:
                VideoPlayer1.SetActive(false);
                VideoPlayer2.SetActive(false);
                VideoPlayer3.SetActive(false);
                VideoPlayer4.SetActive(false);
                VideoPlayer5.SetActive(true);
                break;
        }
    }
    void Randomize()
    {
        RandomNumber = Random.Range(0, 6);
        if (RandomNumber == previousShort)
        {
            Randomize();
        }
        else
        {
            previousShort=RandomNumber;
        }
    }
}
