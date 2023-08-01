using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchor : MonoBehaviour
{
    //public Transform cameraTransform;
    public float followRadius = 8f;
    public float followSpeed = 5f;
    private bool isSelected;
    private bool gazedAt;
    private float timer;
    [SerializeField] private GazeManager gazeManager;
    [SerializeField] private TimeController timeController;
    [SerializeField] private GazeMove one;
    



    private void Update()
    {
        if (gazedAt && !isSelected)
        {
            
            timer += Time.deltaTime;

            // Comprobar si el tiempo requerido de mirada ha sido alcanzado
            if (timer >= gazeManager.timeForSelection)
            {
               
                // Seleccionar el objeto
                isSelected = true;
               
                OnObjectSelected();
            }
        }
        if (isSelected&&!one.one)
        {
             //this.transform.LookAt(cameraTransform, Vector3.up);
            // Calcula la dirección desde el objeto actual hacia el objeto objetivo
            Vector3 direction = Camera.main.transform.position - transform.position;

            // Calcula el ángulo en radianes en base a la dirección
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Crea una rotación en el eje Y usando el ángulo calculado
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

            // Aplica la rotación al objeto actual
            transform.rotation = rotation;
        }
        
        if (!timeController.timeGrabBool&&timeController.left)
        {
            if(transform.CompareTag("Untagged"))
            {
                leftObject();
            }
            
        }

        
        
        
       
    }
    private void LateUpdate()
    {
        if (isSelected && !one.one)
        {
            //this.transform.LookAt(cameraTransform);
            // Obtener la posición del centro de la cámara
            Vector3 cameraCenter =  new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y-0.15f,Camera.main.transform.position.z) + Camera.main.transform.forward * followRadius;

            // Calcular la dirección del movimiento
            Vector3 direction = cameraCenter - transform.position;
           // direction.y= 0f; // Opcionalmente, puedes bloquear el movimiento en el eje Y para que el objeto no suba o baje.

            // Mover el objeto en la dirección calculada
            transform.position += direction * followSpeed * Time.deltaTime;
            
        }
        
    }

    public void OnObjectSelected()
    {
        // Aquí puedes agregar cualquier código adicional que desees ejecutar cuando el objeto es seleccionado
        Debug.Log("Objeto seleccionado");
        Destroy(transform.gameObject.GetComponent<Rigidbody>());
        timeController.timeGrabBool=true;
        transform.gameObject.tag="Untagged";
        
    }
     public void OnPointerEnterXR()
    {
        gazedAt = true;
        

    }

    public void OnPointerExitXR()
    {
        gazedAt = false;
        timer = 0;
       

    }
    public void DeselectObject(GameObject other)
    {
        gazedAt = false;
        isSelected = false;
        transform.position = new Vector3(other.gameObject.transform.position.x+Random.Range(-0.2f,0.2f),transform.position.y+0.3f,other.gameObject.transform.position.z);
        transform.gameObject.AddComponent<Rigidbody>();
        transform.gameObject.tag="inBox";
        one.one = false;
        timeController.timeGrabBool = false;

        if (!one.panelTuto.activeSelf && !one.yaEntro)
        {
            one.panelTuto.SetActive(true);
            one.yaEntro = true;
           
        }
        
        
    }
        
    private void OnTriggerEnter(Collider other)   
    {
        if( other.gameObject.CompareTag("Container")&& transform.gameObject.CompareTag("Untagged"))
        {
            DeselectObject(other.gameObject);
            //meta = true;
        }
       
    }
    void leftObject()
    {
        gazedAt = false;
        isSelected = false;
        transform.position = new Vector3(transform.gameObject.transform.position.x,transform.position.y,transform.gameObject.transform.position.z);
        transform.gameObject.AddComponent<Rigidbody>();
        transform.gameObject.tag="Interactable";
        one.one = false;
        timeController.timeGrabBool = false;


    }
    


}
