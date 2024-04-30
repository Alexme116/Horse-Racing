using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePlayer : MonoBehaviour
{
    private float jumpForce = 5f; // Fuerza del salto
    private bool isJumping = false; // Variable para controlar si el caballo está saltando
    private float jumpDuration = 0.7f; // Duración total del salto (1 segundo hacia arriba, 1 segundo hacia abajo)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hacer que el caballo salte
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;

        for (float i = 0; i < jumpDuration / 2; i += Time.deltaTime)
        {
            transform.position += new Vector3(0, jumpForce * Time.deltaTime, 0);
            yield return null;
        }

        for (float i = 0; i < jumpDuration / 2; i += Time.deltaTime)
        {
            transform.position += new Vector3(0, -jumpForce * Time.deltaTime, 0);
            yield return null;
        }

        isJumping = false;
    }
}
