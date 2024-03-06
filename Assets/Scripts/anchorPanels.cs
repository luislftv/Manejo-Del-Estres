using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorPanels : MonoBehaviour
{
     private float followRadius;
    [SerializeField] private float followSpeed;

    private void Update()
    {
        //this.transform.LookAt(cameraTransform, Vector3.up);
        // Calcula la direcci�n desde el objeto actual hacia el objeto objetivo
        Vector3 direction = Camera.main.transform.position - transform.position;

        // Calcula el �ngulo en radianes en base a la direcci�n
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Crea una rotaci�n en el eje Y usando el �ngulo calculado
        Quaternion rotation = Quaternion.Euler(0f, angle - 180, 0f);

        // Aplica la rotaci�n al objeto actual
        transform.rotation = rotation;
    }
    private void LateUpdate()
    {
        //this.transform.LookAt(cameraTransform);
        // Obtener la posici�n del centro de la c�mara
        Vector3 cameraCenter = Camera.main.transform.position + Camera.main.transform.forward * 0.7f;

        // Calcular la direcci�n del movimiento
        Vector3 direction = cameraCenter - transform.position;
        direction.y = 0f; // Opcionalmente, puedes bloquear el movimiento en el eje Y para que el objeto no suba o baje.

        // Mover el objeto en la direcci�n calculada
        transform.position += direction * followSpeed * Time.deltaTime;
    }
}
