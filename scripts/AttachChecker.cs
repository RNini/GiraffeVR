using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachChecker : MonoBehaviour
{
    public bool DNAattached;
    public bool headAttached;
    public bool legsAttached;

    public bool allAttached;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void allAttachCheck()
    {
        if (DNAattached && headAttached && legsAttached)
        {
            allAttached = true;
        }
    }
}
