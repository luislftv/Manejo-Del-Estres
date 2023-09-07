using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private GameObject panelTuto;
    [SerializeField] TimeController  timeBool;
    // Start is called before the first frame update
    public void OnPointerClickXR()
    {
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
