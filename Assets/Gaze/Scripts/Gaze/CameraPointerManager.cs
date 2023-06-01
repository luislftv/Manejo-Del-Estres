using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject _pointerUnselectObject;
    [SerializeField] private GameObject _objectToPoninterDefault;
    private bool _unselect;
    [SerializeField] private float maxDistancePointer = 4.5f;
    [Range(0, 1)][SerializeField] private float disPointerObj = 0.95f;
    private readonly string interactableTag = "Interactable";
    private float scaleSize = 0.025f;
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    private void Start() 
    {
        //Evento a ejecutar
        GazeManager.Instance.OnGazeSelection += GazeSelection;

        //Ajustar posicion de GO de colision por defecto.
        //OJO inicialmente la posicion del objeto debe ser 0,0,0 e igual su Z a la ongitud del RayCast.
        _objectToPoninterDefault.transform.localPosition = Vector3.forward * this.maxDistancePointer;
    }

    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
    }

    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            //print(hit.collider.name);
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                //Cambio de evento segun objeto seleccionado.
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection(); //Iniciar contador del Gaze

            }
            //Ingresó puntero a objeto valido para ejecutar evento.
            if(hit.transform.CompareTag(interactableTag))
            {
                PointerOnGaze(hit.point);
            }
            else
            {
                //Apagar puntero de carga
                PointerOutGaze();
                //Ejecutar puntero basico SIN carga (GAZE).
                //PointerUnselect(hit);    
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
        }
    }

    //Calculo para el pointer que apunta a un target-----------------
    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scaleFactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position,
                                    hitPoint,
                                    disPointerObj);
    }

    //Calculo para el pointer que NO apunta a un target-----------------
    private void PointerUnselect(RaycastHit hit)
    {
        print('a');
        Vector3 hitPoint = hit.point;
        float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        _pointerUnselectObject.transform.localScale = Vector3.one * scaleFactor;
        _pointerUnselectObject.transform.parent.position = CalculatePointerPosition(transform.position,
                                    hitPoint,
                                    disPointerObj);
    }
    
    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);

        return new Vector3(x, y, z);
    }

    public void PointerOutGaze()
    {
        pointer.transform.localScale = Vector3.one * 0.1f;
        pointer.transform.parent.transform.localPosition 
            = new Vector3(0,0, maxDistancePointer);
        pointer.transform.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }
}
