using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f; // Velocidad de movimiento del personaje
    public float fuerzaSalto = 10.0f; // Fuerza del salto
    private bool enSuelo = true; // ¿Está el personaje en el suelo?

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mover el personaje lateralmente
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0);
        rb.velocity = new Vector2(movimiento.x * velocidadMovimiento, rb.velocity.y);

        // Hacer que el personaje salte si está en el suelo y se presiona la tecla de salto (por ejemplo, barra espaciadora)
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Detectar si el personaje ha tocado el suelo
        if (col.gameObject.CompareTag("Floor"))
        {
            enSuelo = true;
        }
    }
}
