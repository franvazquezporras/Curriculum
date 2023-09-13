using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShake : MonoBehaviour
{
    public float tiempoDeTemblores = 1.0f;
    public float intensidadDeTemblores = 0.1f;
    public GameObject izquierdaParte;
    public GameObject derechaParte;
    public GameObject centralParte;
    public float velocidadDeCaida = 2.0f;

    private Vector3 posicionInicial;
    private bool plataformaTemblando = false;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (plataformaTemblando)
        {
            // Simula el temblor de la plataforma
            float offsetX = Random.Range(-intensidadDeTemblores, intensidadDeTemblores);
            float offsetY = Random.Range(-intensidadDeTemblores, intensidadDeTemblores);
            transform.position = posicionInicial + new Vector3(offsetX, offsetY, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!plataformaTemblando)
            {
                // Comienza el temblor cuando el jugador lo toca
                plataformaTemblando = true;
                Invoke("DescomponerPlataforma", tiempoDeTemblores);
            }
        }
    }

    void DescomponerPlataforma()
    {
        // Desactiva la parte central
    

        // Comienza una corutina para hacer caer las partes izquierda y derecha una por una
        StartCoroutine(CaerPartesSecuencialmente());
    }

    IEnumerator CaerPartesSecuencialmente()
    {
        // Espera 1 segundo antes de dejar caer la parte izquierda

        derechaParte.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(EncogerCollider());


        // Espera 1 segundo antes de dejar caer la parte derecha
        izquierdaParte.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(0.5f);
        derechaParte.SetActive(false);


        // Espera 1 segundo antes de desactivar las partes izquierda y derecha

        centralParte.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(0.5f);
        izquierdaParte.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        
        centralParte.SetActive(false);
        gameObject.SetActive(false);
    }

    IEnumerator EncogerCollider()
    {
        Vector3 colliderO = gameObject.GetComponent<BoxCollider2D>().size;
        float tiempoDeEncogimiento = 1f;
        float tiempoPasado = 0f;
        while (tiempoPasado < tiempoDeEncogimiento)
        {
            float t = tiempoPasado / tiempoDeEncogimiento;

            // Interpola el tamaño del colisionador hacia el centro
            gameObject.GetComponent<BoxCollider2D>().size = Vector2.Lerp(colliderO, Vector2.zero, t);

            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        // Desactiva el colisionador
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
}
