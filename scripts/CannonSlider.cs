using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BNG
{
    public class CannonSlider : MonoBehaviour
    {
        public Slider mySlider;
        public Animator myCannonAnim;

        public bool fireMode;

        private bool initialize = true;                    // Hacky way of preventing animation snapping the first time we go into shoot mode
                                                           // Previously, the turn animation played before the extension animation after the first
                                                           // mode switch

        // Start is called before the first frame update
        void Start()
        {
            fireMode = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void rotateMyObject()
        {
            // If the initialize bool has been set to false, we can turn the cannon
            if (!initialize)
            {
                if (fireMode)
                {

                    // Sets the animation frame of "cannon turn" to mapped slide value
                    myCannonAnim.Play("CannonTurn", 0, (mySlider.SlidePercentage) / 100);
                }
            }
            
            // Sets the initialize bool so we can adjust the cannon turn
            else { initialize = false; }
             
        }
        

        public void setMode()
        {
            // Flips the boolean logic, which we will map to the mode-switch button
            if (!fireMode) 
            {
                Debug.Log("check this");
                fireMode = true; 
            }

            else { fireMode = false; }
        }
    }

}