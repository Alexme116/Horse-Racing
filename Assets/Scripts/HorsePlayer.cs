using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePlayer : MonoBehaviour
{
    private HorseJump horseJump;// Referencia al script que controla el salto

    // Start is called before the first frame update
    void Start()
    {
        // Obtener la referencia al script HorseJump
        horseJump = GetComponent<HorseJump>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hacer que el caballo salte
        if (Input.GetKeyDown(KeyCode.Space))
        {
            horseJump.Saltar();
        }
    }
}
