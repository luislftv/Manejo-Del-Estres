using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorPanels : MonoBehaviour
{
    [SerializeField] private float followRadius;
    [SerializeField] private float followSpeed;

    private void Update()
    {
        //this.transform.LookAt(cameraTransform, Vector3.up);
        // Calcula la dirección desde el objeto actual hacia el objeto objetivo
        Vector3 direction = Camera.main.transform.position - transform.position;

        // Calcula el ángulo en radianes en base a la dirección
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Crea una rotación en el eje Y usando el ángulo calculado
        Quaternion rotation = Quaternion.Euler(0f, angle - 180, 0f);

        // Aplica la rotación al objeto actual
        transform.rotation = rotation;
    }
    private void LateUpdate()
    {
        //this.transform.LookAt(cameraTransform);
        // Obtener la posición del centro de la cámara
        Vector3 cameraCenter = Camera.main.transform.position + Camera.main.transform.forward * followRadius;

        // Calcular la dirección del movimiento
        Vector3 direction = cameraCenter - transform.position;
        direction.y = 0f; // Opcionalmente, puedes bloquear el movimiento en el eje Y para que el objeto no suba o baje.

        // Mover el objeto en la dirección calculada
        transform.position += direction * followSpeed * Time.deltaTime;
    }
}
