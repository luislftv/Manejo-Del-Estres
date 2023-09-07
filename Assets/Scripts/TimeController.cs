using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [HideInInspector] public float time;
    [HideInInspector] public bool timeBool;
    public float timeGrab;
    [HideInInspector]public bool timeGrabBool;
    [HideInInspector]public bool left;
    [HideInInspector] public bool GO3;
    [SerializeField] float timeLose;
    [SerializeField] TextMeshProUGUI timeTxtReal;
    [SerializeField] TextMeshProUGUI timeTxt;
    [SerializeField] GameObject messeageTxt;
    [SerializeField] GameObject Estreslvl;
    [SerializeField] float fixTime;
    public int momento;
    public bool stressBool;
 

    // Start is called before the first frame update
    void Start()
    {
        timeTxt.enabled=false;
        timeTxt.text="00";
        messeageTxt.SetActive(false);
        timeTxtReal.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBool) 
        {
            time += Time.deltaTime;
            timeTxtReal.enabled = true;
            timeTxtReal.text = time.ToString("00");
        }

        if(timeGrabBool)
        {   timeTxt.enabled=true;
            messeageTxt.SetActive(false);
            timeGrab +=Time.deltaTime;
            timeTxt.text=timeGrab.ToString("00");
            left = false;
            if (timeGrab>=timeLose)
            {
                left=true;
                timeGrabBool=false;
                timeTxt.enabled=false;
                messeageTxt.SetActive(true);
                timeGrab =0;
            }
            
        }
        else
        {
            left = false;
            timeGrab = 0;
            timeTxt.enabled = false;
            

        }
        if (time >= fixTime) 
        {
            timeBool = false;
            Estreslvl.SetActive(true);

        }
        if (time >= fixTime-3)
        {
            timeTxtReal.color = Color.red;

        }
        if (stressBool) 
        {
            Estreslvl.SetActive(false);
            
            
            
        }

    }

   



    
}
