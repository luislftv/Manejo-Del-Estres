using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GazeMove : MonoBehaviour {

    // La distancia máxima a la que se puede seleccionar un objeto
    public float maxDistance = 10f;

    // El objeto seleccionado actualmente
    [SerializeField] private GameObject selectedObject;

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
    [SerializeField] GameObject toysTxt;
    [SerializeField] private GameObject particulas;
    [SerializeField] public GameObject panelTuto;
    [HideInInspector] public bool yaEntro;
    [SerializeField] private GameObject limit;
    public GameObject[] toys= new GameObject[5];
    [SerializeField] private GameObject banda;
    [SerializeField] private SpawnScript spawn;
     public string layer;
    public bool lay;

    [SerializeField] private GameObject descarte;
    [SerializeField] private GameObject feedback1;

    GameObject ant;

    private void Start() {
        ant = new GameObject(); 
        
    }

   void Update()
    {
       

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            try
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    anim.grab();

                    timer += Time.deltaTime;
                    if (timer >= gazeTime.timeForSelection)
                    {
                        selectedObject = hit.transform.gameObject;
                    }


                }
                else if(!hit.collider.CompareTag("table"))
                { timer = 0; }

                if (selectedObject != null)
                {
                    timer = 0;


                    if (selectedObject.CompareTag("inBox"))
                    {
                        anim.drop();
                        if (!parts.Contains(selectedObject))
                        {
                           
                            parts.Add(selectedObject);
                            if (!lay) 
                            {
                                layer = selectedObject.layer.ToString();
                                lay = true;
                            }
                            if (!layer.Equals(selectedObject.layer.ToString())) 
                            {
                                feedback1.SetActive(true);
                                selectedObject.transform.position = descarte.transform.position;
                                selectedObject.tag = "Interactable";
                                parts.Remove(selectedObject);
                                selectedObject = null;
                            }
                            else { feedback1.SetActive(false); }
                            

                        }
                        limit.SetActive(false);
                        selectedObject = null;
                    }
                    
                    if (selectedObject.CompareTag("Selected"))
                    {
                        limit.SetActive(true);
                    }
                  
                    if (timeController.timeGrabBool == false&& timeController.left) 
                    {
                        limit.SetActive(false);
                        selectedObject = null;
                        anim.drop();
                    }

                }

            }
            catch (System.Exception)
            {

                
            }
           
           
        
            if (hit.collider.CompareTag("table"))
            {
                GameObject table = hit.collider.gameObject;
                
                timer += Time.deltaTime;
                    if (timer >= gazeTime.timeForSelection)
                    {
                    int ver = veri();
                        if (ver >= 5)
                            {
                                particulas.SetActive(true);
                                anim.fix();

                            
                            
                                totalToys++;
                                toysTxt.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Juguetes: " + totalToys.ToString();
                                toysTxt.SetActive(true);
                            

                                switch (parts[0].layer)
                                    {
                                        case 6:
                                toys[0].transform.position = new Vector3(table.transform.position.x, toys[0].transform.position.y, table.transform.position.z);
                                toys[0].SetActive(true);
                                StartCoroutine(toy(toys[0]));
                                            break;
                                        case 7:
                                toys[1].transform.position = new Vector3(table.transform.position.x, toys[1].transform.position.y, table.transform.position.z);
                                toys[1].SetActive(true);
                                StartCoroutine(toy(toys[1]));
                                            break;
                                        case 8:
                                toys[2].transform.position = new Vector3(table.transform.position.x, toys[2].transform.position.y, table.transform.position.z);
                                toys[2].SetActive(true);
                                StartCoroutine(toy(toys[2]));
                                            break;
                                        case 9:
                                toys[3].transform.position = new Vector3(table.transform.position.x, toys[3].transform.position.y, table.transform.position.z);
                                toys[3].SetActive(true);
                                StartCoroutine(toy(toys[3]));
                                            break;
                                        case 10:
                                toys[4].transform.position = new Vector3(table.transform.position.x, toys[4].transform.position.y, table.transform.position.z);
                                toys[4].SetActive(true);
                                StartCoroutine(toy(toys[4]));
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
        spawn.toy = toy;
        yield return new WaitForSeconds(7f);
        spawn.validator = true;
        particulas.SetActive(false);
        lay = false;
    }
    void select(RaycastHit hit) 
    {
        
        
       
        
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
    

}