using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float distanciaMaxima = 5.0f; // La distancia máxima entre los puntos generados
    public float velocidad = 2.0f;

    private Vector3 puntoA;
    private Vector3 puntoB;
    private Transform plataforma;
    private bool enMovimiento = true;

    private void Start()
    {
        plataforma = transform;
        puntoA = plataforma.position;
        puntoB = puntoA + new Vector3(distanciaMaxima, 0, 0);
    }

    private void Update()
    {
        if (enMovimiento)
        {
            MoverPlataforma(puntoA);

            if (Vector3.Distance(plataforma.position, puntoA) < 0.1f)
            {
                CambiarDestino();
            }
        }
        else
        {
            MoverPlataforma(puntoB);

            if (Vector3.Distance(plataforma.position, puntoB) < 0.1f)
            {
                CambiarDestino();
            }
        }
    }

    private void MoverPlataforma(Vector3 target)
    {
        plataforma.position = Vector3.MoveTowards(plataforma.position, target, velocidad * Time.deltaTime);
    }

    private void CambiarDestino()
    {
        enMovimiento = !enMovimiento;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
