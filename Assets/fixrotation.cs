using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixrotation : MonoBehaviour
{
    // Start is called before the first frame update
private Quaternion initialRotation;
 private Vector3 initialPosition;
float distanceFromCamera = 1f;
private Vector3 offset;

    void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = transform.position;
        
    
    }

    void Update()
    {
        // Mantén la rotación inicial en el eje vertical (Y)
        Quaternion horizontalRotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        Vector3 cameraCenter = Camera.main.transform.position + Camera.main.transform.forward *-0.1f;
        
        // Calcular la direcci�n del movimiento
        Vector3 direction = cameraCenter - transform.position;
        direction.y = 0f;
       // direction.x = 0f;
        direction.z = 0f; // Opcionalmente, puedes bloquear el movimiento en el eje Y para que el objeto no suba o baje.

        // Mover el objeto en la direcci�n calculada
        transform.position += direction;
        


        // Combina la rotación inicial con la rotación horizontal
        transform.rotation = initialRotation * horizontalRotation;
    
    }
}
