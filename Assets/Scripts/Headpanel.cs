using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headpanel : MonoBehaviour
{
 
   
    [SerializeField] private GameObject panelHead;
    [SerializeField] private GameObject firstPanel;

    public void OnPointerClickXR()
    {
        firstPanel.SetActive(true);
        panelHead.SetActive(false);
    }
}
