using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG
{
    public class CompleteVirus : MonoBehaviour
    {
        public GameObject scriptContainer;

        //This is so that the trigger doesn't count for the virus unless it has all of the correct parts attached
        public int virusBuild;

        public GameObject[] allViruses;
        public GameObject instantiateHere;

        // public bool spawnBool;                      // Keeps track of whether an imcomplete virus is spawned
            public GameObject incompleteVirus;          // Temp variable for instantiating incomplete viruses

        // Start is called before the first frame update
        void Start()
        {
            scriptContainer = GameObject.Find("ScriptContainer");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CompletedVirus()
        {

        }


        void OnTriggerEnter(Collider other)
        {
            //when the virus enters the box collider, this will be triggered to get rid of it from the scene and "turn" it into ammo for the shooting scene
            if (other.gameObject.tag == "CompleteVirus")
            {
                if (other.gameObject.GetComponent<AttachChecker>() != null)
                {
                    if (other.gameObject.GetComponent<AttachChecker>().allAttached)
                    {
                        // Removes virus prefab                       
                        Destroy(other.gameObject);
                            
                            // Increases ammo count
                            scriptContainer.GetComponent<Ammunition>().increaseAmoCount();

                        // Reassigns a null to the incomplete virus variable
                        incompleteVirus = null;

                    }

                }

            }

        }


        public void loadVirus()
        {
            // Plays the particle system on the incomplete virus
            incompleteVirus.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }

        public void newVirus()              // We will use an animation trigger to activate this function
        {
            // Only instantiate a new virus if there isn't one currently being built
            if (incompleteVirus == null)
            {
                //Instantiate new partially completed virus for the player
                //Chooses randomly from array and assigns it to the temp variable
                incompleteVirus = Instantiate(allViruses[Random.Range(0, 7)], instantiateHere.transform.position, instantiateHere.transform.rotation);
            }

            // We move the current incomplete virus back to the loader as a fail-safe
            else { incompleteVirus.transform.position = instantiateHere.transform.position; }
            
        }
    }
}

