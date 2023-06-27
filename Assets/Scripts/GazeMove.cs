using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

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
    [HideInInspector] public bool one;
    [SerializeField] private int totalToys;
    [SerializeField] TextMeshProUGUI toysTxt;
    [SerializeField] private GameObject particulas;
    [SerializeField] public GameObject panelTuto;
    [HideInInspector] public bool yaEntro;
    GameObject fullDog;
    GameObject fullCrab;
    

    GameObject ant;

    private void Start() {
        ant = new GameObject();
        fullDog = GameObject.FindGameObjectWithTag("fullDog");
        fullCrab = GameObject.FindGameObjectWithTag("fullCrab");
        
        
    }

   void Update()
    {   
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {

            select(hit);
            
            if (selectedObject!=null)
            { timer = 0;
                
                
                if (selectedObject.CompareTag("inBox"))
                {
                   // Debug.Log(selectedObject.gameObject.name);
                    if (!parts.Contains(selectedObject))
                    {
                        parts.Add(selectedObject);
                    }
                    
                    selectedObject = null;
                }
               
                
            }
            else 
            {
                select(hit);
            }
           
        
            if (hit.collider.CompareTag("table"))
            {
               
                    
                    timer += Time.deltaTime;
                    if (timer >= gazeTime.timeForSelection)
                    {
                    int ver = veri();
                    if (ver >= 5)
                        {
                            particulas.SetActive(true);
                            anim.fix();

                            Debug.Log("Bien hecho");
                            
                            totalToys++;
                            toysTxt.text = "Juguetes: " + totalToys.ToString();
                            toysTxt.enabled = true;
                            

                            switch (parts[0].layer)
                                {
                                    case 6:
                                        StartCoroutine(toy(fullDog));
                                        break;
                                    case 7:
                                        StartCoroutine(toy(fullCrab));
                                        break;

                                }
                                foreach (var item in parts)
                                {
                                    item.SetActive(false);

                                }

                                parts.Clear();


                        }

                    }
                
            }
           
        }
        else
        {

            timer = 0f;
        }

        
    }

    IEnumerator toy(GameObject toy) 
    {
        yield return new WaitForSeconds(7f);
        particulas.SetActive(false);
        toy.transform.localScale = new Vector3(1, 1, 1);
    }
    void select(RaycastHit hit) 
    {
        if (hit.collider.CompareTag("Interactable"))
        {

            timer += Time.deltaTime;
            if (timer >= gazeTime.timeForSelection)
            {
                selectedObject =  hit.transform.gameObject;
            }
            Debug.Log(selectedObject.name);
        }
        
    }
    int veri()
    {
        int count=0;

        if (parts != null)
        {
            foreach (GameObject i in parts)
            {
                if (parts != null)
                {
                    if (parts.Count == 0)
                    {
                        ant = i;
                        if (i.layer == ant.layer)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (i.layer == ant.layer)
                        {
                            count++;
                        }
                        ant = i;
                    }
                }
            }
            
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