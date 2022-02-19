using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBacteria : MonoBehaviour
{
    public GameObject bacteriaPanel;
    private AudioSource bacteriaSound;
    public AudioClip destroySound;

    // Start is called before the first frame update
    void Start()
    {
        bacteriaSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If the complete virus shoots out of the cannon and hits me- this will be destoryed
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "CompleteVirus")
        {
            //Destroy(this.gameObject);
            bacteriaPanel.SetActive(false);

            bacteriaSound.PlayOneShot(destroySound);
        }

    }


}
