using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachDNA : MonoBehaviour
{
    public GameObject DNA;
    public int DNAtoHeadCount;

    public AttachChecker myChecker;

    
    void OnTriggerEnter(Collider other)
    {
        //if the object triggered has tag DNA and we have never touched one before, trigger actions
        if (other.gameObject.tag == "DNA" & DNAtoHeadCount < 1)
        {
            //increase head count so that we can't attach any more
            DNAtoHeadCount++;
            //Destroy this gameobject that we are trying to attach
            DestroyObject(other.gameObject);
            //Set the hidden game object (of the DNA head attached) to be visible
            DNA.SetActive(true);

            // set the bool checking if DNA has been attached to true
            myChecker.DNAattached = true;
            myChecker.allAttachCheck();
        }

    }
}
