using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    [SerializeField] private GameObject panelTuto;
    bool yaEntro;
    // Start is called before the first frame update
    public void OnPointerEnterXR()
    {
        if (!panelTuto.activeSelf && !yaEntro)
        {
            panelTuto.SetActive(true);
            yaEntro = true;
        }


    }
}

