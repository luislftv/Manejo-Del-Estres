using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject final;
    [SerializeField] private TimeController stressBool;

    public void OnPointerClickXR()
    {
        final.SetActive(true);
        stressBool.GO3 = true;
        
    }
}
