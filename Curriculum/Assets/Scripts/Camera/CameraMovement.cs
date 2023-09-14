using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smoothTime = 0.2f;
    public Vector2 maxXLimits = new Vector2(-2f, 2f);
    public Vector2 maxYLimits = new Vector2(-1f, 2f);
    public float zDistance = 10f; // Distancia Z desde la c�mara hacia el plano del mundo

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Obtener la posici�n del cursor en la pantalla
        Vector3 cursorPositionScreen = Input.mousePosition;

        // Convertir la posici�n del cursor en la pantalla a una posici�n en el mundo
        Vector3 cursorPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(cursorPositionScreen.x, cursorPositionScreen.y, zDistance));

        // Calcular la posici�n de destino de la c�mara
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(cursorPositionWorld.x, maxXLimits.x, maxXLimits.y),
            Mathf.Clamp(cursorPositionWorld.y, maxYLimits.x, maxYLimits.y),
            transform.position.z
        );

        // Calcular la posici�n suavizada
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Actualizar la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}
