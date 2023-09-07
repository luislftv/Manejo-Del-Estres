using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
     public GameObject toy;
    public bool validator;
 
  
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.CompareTag("banda")&& validator)
            {
                GameObject banda = other.gameObject;
                ///banda.transform.GetChild(1).gameObject.SetActive(true);
                toy.transform.parent = banda.transform;
                toy.transform.position = new Vector3(banda.transform.position.x, toy.transform.position.y, banda.transform.position.z);
                validator = false;

            }
        }
        catch (System.Exception)
        {


        }
    }
}
