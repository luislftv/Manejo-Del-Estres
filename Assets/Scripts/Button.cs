using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject panelTuto;
    // Start is called before the first frame update
    public void OnPointerClickXR()
    {
        panelTuto.SetActive(false);
    }
    public void OnPointerEnter(string hola)
    {
       
    }
    public void OnPointerExit()
    {
        
    }
}
