using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smoothTime = 0.2f;
    public Vector2 maxXLimits = new Vector2(-2f, 2f);
    public Vector2 maxYLimits = new Vector2(-1f, 2f);
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = transform.position.z;

        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(cursorPosition.x, maxXLimits.x, maxXLimits.y),
            Mathf.Clamp(cursorPosition.y, maxYLimits.x, maxYLimits.y),
            transform.position.z
        );

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = smoothedPosition;
    }
}
