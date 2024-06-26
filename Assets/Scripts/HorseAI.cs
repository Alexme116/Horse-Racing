using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAI : MonoBehaviour
{
    // Distancia en el eje X para la detección
    public float distanciaDeteccionX = 1.0f;
    // Margen de error en el eje Y
    public float margenErrorY = 1.0f;

    // Lista para almacenar las vallas ya detectadas
    private List<GameObject> vallasDetectadas = new List<GameObject>();

    // Referencia al script que controla el salto
    private HorseJump horseJump;

    void Start()
    {
        // Obtener la referencia al script HorseJump
        horseJump = GetComponent<HorseJump>();
    }

    void Update()
    {
        // Buscar todos los objetos con el tag "Valla"
        GameObject[] vallas = GameObject.FindGameObjectsWithTag("Valla");

        foreach (GameObject valla in vallas)
        {
            // Si la valla ya fue detectada, continuar con la siguiente
            if (vallasDetectadas.Contains(valla))
                continue;

            // Calcular la distancia en el eje X y el eje Y
            float distanciaX = Mathf.Abs(transform.position.x - valla.transform.position.x);
            float distanciaY = Mathf.Abs(transform.position.y - 1.0f - valla.transform.position.y);

            // Si la distancia es menor o igual a la distancia de detección en X y dentro del margen de error en Y
            if (distanciaX <= distanciaDeteccionX && distanciaY <= margenErrorY)
            {
                // Generar un número aleatorio entre 1 y 10
                int numeroAleatorio = Random.Range(1, 11);

                // Añadir la valla a la lista de detectadas
                vallasDetectadas.Add(valla);

                // Si el número aleatorio es mayor a 2, hacer que el GameObject salte
                if (numeroAleatorio > 2)
                {
                    horseJump.Saltar();
                }
            }
        }

        // Verificar si el caballo ha pasado la valla
        foreach (GameObject valla in vallasDetectadas.ToArray())
        {
            if (transform.position.x > valla.transform.position.x)
            {
                vallasDetectadas.Remove(valla);
                // Permitir futuras detecciones limpiando la lista de vallas detectadas
                vallasDetectadas.Clear();
            }
        }
    }
}
