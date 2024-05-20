using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;

public class LoadImagesv2 : MonoBehaviour
{
    public InputField input;
public string imageUrl;
    public RawImage image;
    public Texture NoImage;

   public void Print()
    {
        imageUrl=input.text;
        if (imageUrl =="")
{
image.texture =NoImage;
}
else{
        StartCoroutine(DownloadImage(imageUrl));

       Invoke("IdontKnowWhatImDoing",1.5f);
    }
       } 
    public void IdontKnowWhatImDoing()
    {
        if (downloadedImage != null)
        {
            image.texture = downloadedImage;
            if (downloadedImage.height > downloadedImage.width)
            {
                image.rectTransform.rotation = Quaternion.Euler(0, 0, -90);
            }
            //16/9
            if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (16f / 9f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (16f / 9f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(1920, 1080);
                image.rectTransform.localScale = new Vector3(0.093f, 0.093f, 0.093f);
                Debug.Log("image is 16*9");
            }
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (9f / 16f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (9f / 16f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(1080, 1920);
                image.rectTransform.localScale = new Vector3(0.093f, 0.093f, 0.093f);
                Debug.Log("image is 16*9");
            }
            //21/9
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (21f / 9f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (21f / 9f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(2560, 1080);
                image.rectTransform.localScale = new Vector3(0.0697f, 0.0697f, 0.0697f);
                Debug.Log("image is 21*9");
            }
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (9f / 21f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (9f / 21f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(1080, 2560);
                image.rectTransform.localScale = new Vector3(0.0697f, 0.0697f, 0.0697f);
                Debug.Log("image is 21*9");
            }
            //5/4
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (5f / 4f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (5f / 4f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(1280, 1024);
                image.rectTransform.localScale = new Vector3(0.0973f, 0.0973f, 0.0973f);
                Debug.Log("image is 5*4");
            }
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (4f / 5f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (4f / 5f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(1024, 1280);
                image.rectTransform.localScale = new Vector3(0.0973f, 0.0973f, 0.0973f);
                Debug.Log("image is 5*4");
            }
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (4f / 3f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (4f / 3f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(1024, 768);
                image.rectTransform.localScale = new Vector3(0.12999f, 0.12999f, 0.12999f);
                Debug.Log("image is 4*3");
            }
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (3f / 4f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (3f / 4f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(768, 1024);
                image.rectTransform.localScale = new Vector3(0.12999f, 0.12999f, 0.12999f);
                Debug.Log("image is 4*3");
            }
            else if ((((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) > (32f / 9f) - 0.001f) && ((downloadedImage.width * 1f) / (downloadedImage.height * 1f)) < (32f / 9f) + 0.001f)
            {
                image.rectTransform.sizeDelta = new Vector2(0.0464f, 0.0464f);
                image.rectTransform.localScale = new Vector3(0.12999f, 0.12999f, 0.12999f);
                Debug.Log("image is 32*9");
            }
            //1/1
            else if (downloadedImage.width == downloadedImage.height)
            {
                image.rectTransform.sizeDelta = new Vector2(1920, 1920);
                image.rectTransform.localScale = new Vector3(0.0517f, 0.0517f, 0.0517f);
                Debug.Log("image is 1*1");
            }


        }
    }
IEnumerator DownloadImage(string url)
    {
       
        WWW www = new WWW(url);

        yield return www;
        if (www.texture!=null)
        {
            downloadedImage = www.texture;
        }
        else
            {
                image.texture = NoImage;
            }
        
    }

    private Texture2D downloadedImage;
}