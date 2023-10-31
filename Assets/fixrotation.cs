using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixrotation : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 position;

    void Start()
    {
       
        position = transform.position;
    }


    void Update()
    {

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        transform.position = position;

    }


}
