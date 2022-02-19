using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class AnimationEventManager : MonoBehaviour
    {
        public GameObject virusTrigger;

        public GameObject scriptContainer;

        // Plays particles when the virus is loaded
        public void triggerLoad()
        {
            virusTrigger.GetComponent<CompleteVirus>().loadVirus();
        }
        
            // Runs the new virus function on our Complete Virus script when the animation event is triggered
            public void triggerSpawn()
            {
                virusTrigger.GetComponent<CompleteVirus>().newVirus();
            }

        // Plays the trajectory particles after a certain frame of the cannon extension animation
        public void triggerTrajectory()
        {
            scriptContainer.GetComponent<DeskManager>().startTrajectory();
        }

    }

}

