using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject player;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();

    private void Awake() {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";
        player = GameObject.Find("Your Horse");
    }

    private void Start() {
        CargarDatos();
    }

    public void CargarDatos() {
        if (File.Exists(archivoDeGuardado)) {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            player.GetComponent<PlayerData>().SetCoins(datosJuego.coins);
        } else {
            Debug.Log("No se encontró el archivo de guardado");
        }
    }

    public void GuardarDatos() {
        DatosJuego nuevosDatos = new DatosJuego() {
            coins = player.GetComponent<PlayerData>().GetCoins()
        };

        string datosAGuardar = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, datosAGuardar);

        Debug.Log("Datos guardados");
    }
}