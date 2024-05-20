using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OiShoeske : MonoBehaviour
{
    public Transform player;

    public float flyingSpeed = 5f;
    public float rotationSpeed = 3f;
    public Saving Save;

    void Update()
    {
        if (player != null)
        {

            Vector3 targetDirection = player.position - transform.position;
            targetDirection.y = 0f; 

         
            Quaternion newRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

          
            transform.Translate(Vector3.forward * flyingSpeed * Time.deltaTime);
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null&& other.gameObject.tag!="Player")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(ReactivateAfterDelay(other.gameObject));
        }
        else if(other.gameObject != null&& other.gameObject.tag== "Player")
        {
            Save.EndingSecretInt = 1;
            Save.Save();
            Application.Quit();
        }
    }

    IEnumerator ReactivateAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        obj.SetActive(true);
    }

}
