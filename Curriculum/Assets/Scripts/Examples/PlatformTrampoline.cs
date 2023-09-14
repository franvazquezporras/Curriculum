using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrampoline : MonoBehaviour
{
    public float minPlayerBounceForce = 1f; // Fuerza mínima de rebote del jugador
    public float platformRecoilForce = 5f; // Fuerza de retroceso de la plataforma
    private bool canBounce = true; // Controla si el jugador puede rebotar

    private float playerFallVelocity = 0f; // Variable para almacenar la velocidad de caída del jugador

    private void Update()
    {
        // Actualiza la velocidad de caída del jugador en cada frame
        if (canBounce)
        {
            Rigidbody2D playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerFallVelocity = playerRb.velocity.y;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(playerFallVelocity);
        if (canBounce && collision.gameObject.CompareTag("Player"))
        {

            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Calcula la fuerza de rebote para el jugador como la mitad de su velocidad de caída simulada
                float playerBounceForce = Mathf.Abs(playerFallVelocity) * 0.9f;
                playerBounceForce = Mathf.Max(playerBounceForce, minPlayerBounceForce);

                // Aplica la fuerza de rebote al jugador
                playerRb.velocity = new Vector2(playerRb.velocity.x, playerBounceForce);

                // Aplica el retroceso a la plataforma
                Rigidbody2D platformRb = GetComponent<Rigidbody2D>();
                if (platformRb != null)
                {
                    platformRb.velocity = new Vector2(platformRb.velocity.x, -platformRecoilForce);
                }

                // Impide al jugador rebotar nuevamente hasta que aterrice
                canBounce = false;

                // Restaura la capacidad de rebote después de un tiempo
                StartCoroutine(ResetBounce());
            }
        }
    }

    IEnumerator ResetBounce()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta el tiempo necesario para volver a permitir el rebote
        canBounce = true;
    }
}
