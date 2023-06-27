using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float time;
    float timeGrab;
    [HideInInspector]public bool timeGrabBool;
    [HideInInspector]public bool left;
    [SerializeField] float timeLose;
    [SerializeField] TextMeshProUGUI timeTxt;
    // Start is called before the first frame update
    void Start()
    {
        timeTxt.enabled=false;
        timeTxt.text="00";   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeGrabBool)
        {   timeTxt.enabled=true;

            timeGrab +=Time.deltaTime;
            timeTxt.text=timeGrab.ToString("00");
            if(timeGrab>=timeLose)
            {
                left=true;
                timeGrabBool=false;
                timeTxt.enabled=false;
                timeGrab=0;
            }
            
        }
        else
        {
            timeGrab = 0;
            timeTxt.enabled = false;

        }
    }
    
}
