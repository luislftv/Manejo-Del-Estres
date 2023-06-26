using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MecanicaNueva : MonoBehaviour
{
    public GazeManager gazeManager; // Tiempo requerido de mirada para seleccionar el objeto
    public float movementSpeed = 100f; // Velocidad de movimiento del objeto
    private float timer;
    private bool gazedAt;
    private bool isSelected;
    private Vector3 initialPosition;
    private Renderer _myRenderer;
    public bool meta;
    public bool GaOv;
    //public platsAnimatorScript platsAnimatorScript;

    
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    private void Start()
    {
        initialPosition = transform.position;

        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    private void Update()
    {
        Debug.Log(gazedAt);
        // Comprobar si la mirada está sobre el objeto
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

        // Mover el objeto si está seleccionado
        if (isSelected)
        {
            
            // Obtener la posición del centro de la cámara
            Vector3 cameraCenter = Camera.main.transform.position + Camera.main.transform.forward * 1.7f;

            // Calcular la dirección del movimiento
            Vector3 direction = cameraCenter - transform.position;
            direction.z = 0f; // Opcionalmente, puedes bloquear el movimiento en el eje Y para que el objeto no suba o baje.

            // Mover el objeto en la dirección calculada
            transform.position += direction * movementSpeed * Time.deltaTime;
        }

    }
        void OnCollisionEnter(Collision other) {
       
        if( other.gameObject.CompareTag("meta"))
        {
            DeselectObject();
            meta = true;
        }
        if( other.gameObject.CompareTag("limite"))
        {
            DeselectObject();
            GaOv = true;
        }   
        if( other.gameObject.name == "n1")
        {
           
           // platsAnimatorScript.fase1();
            //Debug.Log(other.gameObject.name);
            other.gameObject.SetActive(false);
            
        }   
        if( other.gameObject.name == "n2")
        {
           
           // platsAnimatorScript.fase2();
            //Debug.Log(other.gameObject.name);
             other.gameObject.SetActive(false);
        }   
        if(  other.gameObject.name == "n3")
        {
           
            //platsAnimatorScript.fase3();
            //Debug.Log(other.gameObject.name);
             other.gameObject.SetActive(false);
        }   
        if(  other.gameObject.name == "n4")
        {
           
           // platsAnimatorScript.fase4();
            //Debug.Log(other.gameObject.name);
            other.gameObject.SetActive(false);
        }   
        
    }

    // Método que se llama cuando la mirada entra en contacto con el objeto
    public void OnPointerEnterXR()
    {
        gazedAt = true;
        
      
    }

    // Método que se llama cuando la mirada sale de contacto con el objeto
    public void OnPointerExitXR()
    {
        gazedAt = false;
        timer = 0f;
    }

    // Método que se llama cuando el objeto es seleccionado
    public void OnObjectSelected()
    {
        // Aquí puedes agregar cualquier código adicional que desees ejecutar cuando el objeto es seleccionado
        Debug.Log("Objeto seleccionado");
        SetMaterial(true);
    }

     private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }


    // Método que se llama cuando el objeto es deseleccionado
    public void DeselectObject()
    {
        gazedAt = false;
        isSelected = false;
        SetMaterial(false);
        transform.position = initialPosition; // Restaurar la posición inicial del objeto
    }
}
