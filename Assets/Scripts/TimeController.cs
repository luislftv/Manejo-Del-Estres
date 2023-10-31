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
    [SerializeField] GameObject timeTxtRealPanel;
    [SerializeField] GameObject timeTxtPanel;
    [SerializeField] TextMeshProUGUI timeTxt;
    [SerializeField] GameObject messeageTxt;
    [SerializeField] GameObject Estreslvl;
    [SerializeField] float fixTime;
    private int min, seg;
    public int momento;
    public bool stressBool;
 

    // Start is called before the first frame update
    void Start()
    {
        timeTxt.enabled=false;
        timeTxt.text="00";
        timeTxtRealPanel.SetActive(false);
        timeTxtPanel.SetActive(false);
        messeageTxt.SetActive(false);
        timeTxtReal.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBool) 
        {
            time += Time.deltaTime;
            timeTxtRealPanel.SetActive(true);
            timeTxtReal.enabled = true;

            min =(int) (time / 60f);
            seg = (int)(time-min*60f);

            timeTxtReal.text = min.ToString("00")+":"+seg.ToString("00");
        }

        if(timeGrabBool)
        {   timeTxt.enabled=true;
            timeTxtPanel.SetActive(true);
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
            timeTxtPanel.SetActive(false);


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
