using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (collision.collider.CompareTag("toy"))
            {
                Destroy(collision.gameObject);

            }
        }
        catch (System.Exception)
        {


        }
    }
}
