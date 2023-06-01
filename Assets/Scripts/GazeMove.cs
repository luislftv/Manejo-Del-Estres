using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GazeMove : MonoBehaviour {

    // La distancia máxima a la que se puede seleccionar un objeto
    public float maxDistance = 10f;

    // El objeto seleccionado actualmente
    private GameObject selectedObject;

    // El rayo que sale de la cámara
    private Ray ray;

    // El punto de impacto del rayo con el objeto
    private RaycastHit hit;

    private float timer;
    [SerializeField] private GazeManager gazeTime;

   

   void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {

                timer += Time.deltaTime;
                
                if (timer >= gazeTime.timeForSelection)
                {
                    selectedObject = hit.collider.gameObject;
                 
                   
                }
            }
            else if (hit.collider.CompareTag("Container"))
            {
                timer += Time.deltaTime;
                
                if (timer >= gazeTime.timeForSelection&&selectedObject!=null)
                {
                    selectedObject.transform.position=hit.collider.gameObject.transform.position;
                    selectedObject.GetComponent<BoxCollider>().enabled=false;
                    selectedObject=null;
                    
                   
                }
               
            }
        }
        else
        {

            timer = 0f;
        }

        
    }
    /*void MoveTowardsObject()
    {

        targetPosition.y = player.transform.position.y;
        float step = moveSpeed * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);

    }*/
}