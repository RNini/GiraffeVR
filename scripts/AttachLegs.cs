using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachLegs : MonoBehaviour
{
    public GameObject Legs;
    public int bodytolegsCount;

    public AttachChecker myChecker;

    // Start is called before the first frame update
    void Start()
    {

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tail" & bodytolegsCount<1)
        {
            bodytolegsCount++;
            DestroyObject(other.gameObject);
            Legs.SetActive(true);

            myChecker.legsAttached = true;
            myChecker.allAttachCheck();
        }

    }


}
