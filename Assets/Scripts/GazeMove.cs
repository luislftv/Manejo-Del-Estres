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
    [SerializeField] private TimeController timeController;
    [SerializeField] private animationController anim;
    [SerializeField] private List<GameObject> parts;
     GameObject ant;

   private void Start() {
    ant = new GameObject();
   }

   void Update()
    {   


        if (selectedObject!=null)
        {
            if (selectedObject.CompareTag("inBox"))
            {
                if(!parts.Contains(selectedObject))
                    {
                        parts.Add(selectedObject);
                    }
                        selectedObject=null;

            }
        }
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                selectedObject=hit.transform.gameObject;
            }
        
            if (hit.collider.CompareTag("table"))
            {
               timer += Time.deltaTime;
                if (timer >= gazeTime.timeForSelection)
                {
                    anim.fix();
                   int ver = veri();
                 Debug.Log(ver);
                if (ver >= 5)
                {
                    Debug.Log("Bien hecho");
                }
                   
                }
                

            }
           
        }
        else
        {

            timer = 0f;
        }

        
    }

    int veri()
    {
        int count=0;
       
        foreach (GameObject i in parts)
        {
            if (parts.Count==0)
            {   ant=i;
                if (i.layer==ant.layer)
                    {
                        count++;
                    }
            }
            else
            {
                if (i.layer==ant.layer)
                    {
                        count++;
                    }
                ant=i;
            }
            //count++;
            
        }
        return count;
    }
    
    /*void MoveTowardsObject()
    {

        targetPosition.y = player.transform.position.y;
        float step = moveSpeed * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);

    }*/
}