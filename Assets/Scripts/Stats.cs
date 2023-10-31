using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI momento1;
    [SerializeField] TextMeshProUGUI momento2;
    [SerializeField] TextMeshProUGUI momento3;
    [SerializeField] GameObject creditos;

    private void Awake()
    {
        momento1.text = "Momento 1: " + PlayerPrefs.GetInt("estresLvl1").ToString();
        momento2.text = "Momento 2: " + PlayerPrefs.GetInt("estresLvl2").ToString();
        momento3.text = "Momento 3: " + PlayerPrefs.GetInt("estresLvl3").ToString();
    }
    public void OnPointerClickXR()
    {
        gameObject.SetActive(true);
    }
}
