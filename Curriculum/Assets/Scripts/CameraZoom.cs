using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;          // Referencia a la cámara principal
    public float zoomSpeed = 2f;       // Velocidad del zoom
    public float minFieldOfView = 20f; // Valor mínimo del campo de visión
    public float maxFieldOfView = 60f; // Valor máximo del campo de visión
    public float smoothSpeed = 5f;     // Velocidad de suavizado

    private Vector3 targetPosition;     // Posición hacia la que se hará el zoom
    private float currentFieldOfView;   // Campo de visión actual
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
            // Almacenar la posición del punto de impacto como destino del zoom
            targetPosition = Input.mousePosition;
        }

        if (isZooming)
        {
            // Calcular la distancia entre la cámara y el punto de impacto
            float distance = Vector3.Distance(mainCamera.transform.position, targetPosition);

            // Calcular el nuevo valor del campo de visión basado en la distancia
            float newFieldOfView = Mathf.Lerp(maxFieldOfView, minFieldOfView, Mathf.InverseLerp(minFieldOfView, maxFieldOfView, distance));

            // Suavizar la transición del campo de visión
            currentFieldOfView = Mathf.Lerp(currentFieldOfView, newFieldOfView, Time.deltaTime * smoothSpeed);

            // Aplicar el nuevo valor del campo de visión a la cámara
            mainCamera.fieldOfView = currentFieldOfView;

            if (Mathf.Approximately(currentFieldOfView, newFieldOfView)) // Detener el zoom cuando se alcance el campo de visión objetivo
            {
                isZooming = false;
            }
        }
    }
}
