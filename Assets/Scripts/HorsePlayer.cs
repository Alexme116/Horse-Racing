using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HorsePlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Finish;
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

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Finish"){
            // hacer que aparezca el mensaje de finish
            Finish.text = "Finish!";
        }
    }
}
