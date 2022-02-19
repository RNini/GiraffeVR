using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeskManager : MonoBehaviour
{
    public Animator[] objectAnimators;                  // All relevant scene pieces that need to be animated are dropped in here
    public int currState;                               // Keeps track of which mode we are in


    public Animator[] deskAnimators;                    // All desk animators are referenced here
        public GameObject chuteSnap;                        // Snap point for virus in virus chute *NOTE* This doesn't work and is currently not used
        public GameObject[] virusPrefabs;                   // Partially constructed virus prefabs for instantiation

    public int loadState;                               // Keeps track of build state, either loading or loaded
        [TextArea]
        public string[] loadButtonText;                     // Holds the text we will use
        public TextMeshProUGUI loadButtonTMP;               // TMP object on button that we'll change

    public GameObject fireButton;                       // This is the button to change between build and shoot modes
        [TextArea]
        public string[] switchButtonText;                     // Holds the text we will use
        public TextMeshProUGUI switchButtonTMP;               // TMP object on button that we'll change

    public ParticleSystem aimTrajectory;                      // Particle system used for aiming

    public GameObject loadButton;                       // Button for loading virus into chute
        public GameObject shootButton;                      // Button for firing viruses from cannon

        public GameObject windows;

    public GameObject cannonSlider;                     // Slider to control cannon movement

    //function for when Build Mode/ Shoot Mode button is pressed
    public void ChangeState()
    {
        //WHEN SHOOT MODE BUTTON IS PRESSED //change scene to Shoot Mode
        if (currState == 0)
        {
            // Cycle the current state index
            currState++;

            // Trigger all shoot mode activation animations
            for (int i = 0; i < objectAnimators.Length; i++)
            {
                objectAnimators[i].SetTrigger("ShootMode");
            }

            // Swap out load and shoot buttons
            loadButton.SetActive(false);
            shootButton.SetActive(true);

            //Show cannon slider
            cannonSlider.SetActive(true);

            // Turns on collider for window
            windows.GetComponent<MeshCollider>().enabled = false;

            // Updates Mode Switch button text
            switchButtonTMP.GetComponent<TextMeshProUGUI>().text = switchButtonText[1];
        }

        //WHEN BUILD MODE BUTTON IS PRESSED //change scene to build mode
        else if (currState == 1)
        {
            // Cycle the current state index
            currState = 0;

            // Trigger all build mode activation animations
            for (int i = 0; i < objectAnimators.Length; i++)
            {
                objectAnimators[i].SetTrigger("BuildMode");
            }

                // Stop the particle system showing the cannon trajectory
                aimTrajectory.Stop();

            // Swap out load and shoot buttons
            loadButton.SetActive(true);
            shootButton.SetActive(false);

            //Hide cannon slider
            cannonSlider.SetActive(false);


            // Turns on collider for window
            windows.GetComponent<MeshCollider>().enabled = true;

            // Updates Mode Switch button text
            switchButtonTMP.GetComponent<TextMeshProUGUI>().text = switchButtonText[0];
        }

        else { Debug.Log("State Index is improperly set"); }
    }

    public void chuteStateChange()
    {
        if (loadState == 0)
        {
            // Cycle the current state index
            loadState++;

            // Sets the LoadVirus function
            LoadVirus();

            // Turn on collider so button can be pressed
            fireButton.GetComponent<BoxCollider>().enabled = false;
                fireButton.GetComponent<Animator>().SetTrigger("Load");
                

        }

        else if (loadState == 1)
        {
            // Cycle the current state index
            loadState = 0;

            // Sets the Reset Chute function
            ResetChute();

            // Turn off collider so button can be pressed
            fireButton.GetComponent<BoxCollider>().enabled = true;
                fireButton.GetComponent<Animator>().SetTrigger("Reset");
        }

        else { Debug.Log("State Index is improperly set"); }
    }

    //function for when load virus button is pressed
    public void LoadVirus()
    {
        deskAnimators[0].SetTrigger("Load");        // Animation for Mode Button
        deskAnimators[1].SetTrigger("Load");        // Animation for Load/Reset Button
        deskAnimators[2].SetTrigger("Load");        // Animation for chute
        deskAnimators[3].SetTrigger("Load");        // Animation for cannon extension

        loadButtonTMP.GetComponent<TextMeshProUGUI>().text = loadButtonText[1];
    }

    //function for when new virus button is pressed
    public void ResetChute()
    {
        deskAnimators[0].SetTrigger("Reset");        // Animation for Mode Button
        deskAnimators[1].SetTrigger("Reset");        // Animation for Load/Reset Button
        deskAnimators[2].SetTrigger("Reset");        // Animation for chute
        deskAnimators[3].SetTrigger("Reset");         // Animation for cannon extension

        loadButtonTMP.GetComponent<TextMeshProUGUI>().text = loadButtonText[0];
    }


    public void startTrajectory()
    {
        // Start the particle system showing the cannon trajectory, to be triggered by an animation event
        aimTrajectory.Play();
    }
}
