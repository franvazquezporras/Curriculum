using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    // Propiedad estática para acceder a la instancia
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                // Busca la instancia existente en la escena
                instance = FindObjectOfType<Singleton>();

                // Si no existe, crea un nuevo objeto
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<Singleton>();
                }

                // Evita que se destruya al cargar una nueva escena
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    private void Awake()
    {
        // Si ya existe una instancia, destruye esta para evitar duplicados
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
