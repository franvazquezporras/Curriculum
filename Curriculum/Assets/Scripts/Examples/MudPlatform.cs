using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudPlatform : MonoBehaviour
{
    private bool isSinking = false;
    private float initialPosition;
    private Collider2D platformCollider;

    public float sinkSpeed = 0.2f;
    public float sinkDistance = 5.0f;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        initialPosition = platformCollider.offset.y;
    }

    void Update()
    {
        if (isSinking)
        {
            // Mover el collider, no la plataforma física
            float step = sinkSpeed * Time.deltaTime;
            platformCollider.offset = Vector3.MoveTowards(platformCollider.offset, new Vector2(platformCollider.offset.x,platformCollider.offset.y - sinkDistance), step);
            // Si el collider de la plataforma ha llegado a su posición hundida deseada
            
            if (platformCollider.offset.y < initialPosition - sinkDistance)
            {
                // Desactivar el collider de la plataforma
                platformCollider.enabled = false;
                // Detener el hundimiento
                isSinking = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isSinking && enabled)
        {
            collision.gameObject.GetComponent<PlayerController>().SetTimeStuned(1f);
            if(!isSinking)
                isSinking = true;
        }
    }
    
}
