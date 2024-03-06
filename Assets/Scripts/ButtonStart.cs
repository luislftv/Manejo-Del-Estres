using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private GameObject panelTuto;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] TimeController  timeBool;
    // Start is called before the first frame update
    public void OnPointerClickXR()
    {
        nextPanel.SetActive(true);
        panelTuto.SetActive(false);
        timeBool.timeBool =true;
        
    }
    public void OnPointerEnter(string hola)
    {
       
    }
    public void OnPointerExit()
    {
        
    }
}
