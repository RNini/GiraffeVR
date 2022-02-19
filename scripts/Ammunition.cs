using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammunition : MonoBehaviour
{
    public int amoCount;
    public TextMeshProUGUI amoCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void increaseAmoCount()
    {
        amoCount++;
        amoCountText.GetComponent<TextMeshProUGUI>().text = " " + amoCount;
        
    }

    public void decreaseAmoCount()
    {
        amoCount--;
        amoCountText.GetComponent<TextMeshProUGUI>().text = " " + amoCount;

    }
}
