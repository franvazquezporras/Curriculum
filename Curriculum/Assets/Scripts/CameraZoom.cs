using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;          // Referencia a la c�mara principal
    public float zoomSpeed = 2f;       // Velocidad del zoom
    public float minFieldOfView = 20f; // Valor m�nimo del campo de visi�n
    public float maxFieldOfView = 60f; // Valor m�ximo del campo de visi�n
    public float smoothSpeed = 5f;     // Velocidad de suavizado

    private Vector3 targetPosition;     // Posici�n hacia la que se har� el zoom
    private float currentFieldOfView;   // Campo de visi�n actual
    private bool isZooming;             // Bandera para controlar el zoom

    void Start()
    {
        currentFieldOfView = mainCamera.fieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detectar clic izquierdo
        {
            isZooming = true; // Comenzar el zoom
            // Almacenar la posici�n del punto de impacto como destino del zoom
            targetPosition = Input.mousePosition;
        }

        if (isZooming)
        {
            // Calcular la distancia entre la c�mara y el punto de impacto
            float distance = Vector3.Distance(mainCamera.transform.position, targetPosition);

            // Calcular el nuevo valor del campo de visi�n basado en la distancia
            float newFieldOfView = Mathf.Lerp(maxFieldOfView, minFieldOfView, Mathf.InverseLerp(minFieldOfView, maxFieldOfView, distance));

            // Suavizar la transici�n del campo de visi�n
            currentFieldOfView = Mathf.Lerp(currentFieldOfView, newFieldOfView, Time.deltaTime * smoothSpeed);

            // Aplicar el nuevo valor del campo de visi�n a la c�mara
            mainCamera.fieldOfView = currentFieldOfView;

            if (Mathf.Approximately(currentFieldOfView, newFieldOfView)) // Detener el zoom cuando se alcance el campo de visi�n objetivo
            {
                isZooming = false;
            }
        }
    }
}
