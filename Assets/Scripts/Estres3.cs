using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estres3 : MonoBehaviour
{
    public int estresLvl;
    [SerializeField] private TimeController stressBool;
    [SerializeField] private GameObject stats;

    public void OnPointerClickXR()
    {
        PlayerPrefs.SetInt("estresLvl3", estresLvl);
        stats.SetActive(true);
        stressBool.stressBool = true;
        
    }
}
