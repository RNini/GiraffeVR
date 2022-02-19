using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHead : MonoBehaviour
{
    public GameObject Head;
    //ensures that we can only add one head object into the trigger zone
    public int headtobodyCount;

    public AttachChecker myChecker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //when we attach the correct object to this trigger zone on the virus, we destroy the object and turn on the mesh that is in the correct position and is currently hidden
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head" & headtobodyCount<1)
        {
            headtobodyCount++;
            DestroyObject(other.gameObject);
            Head.SetActive(true);

            myChecker.headAttached = true;
            myChecker.allAttachCheck();
        }

    }



}
