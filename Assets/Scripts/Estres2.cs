using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Estres2 : MonoBehaviour
{
    public int estresLvl;
    [SerializeField] private TimeController stressBool;
    public void OnPointerClickXR()
    {
        PlayerPrefs.SetInt("estresLvl2", estresLvl);
        stressBool.stressBool = true;
        SceneManager.LoadScene("Momento " + (stressBool.momento + 1));
    }
}
