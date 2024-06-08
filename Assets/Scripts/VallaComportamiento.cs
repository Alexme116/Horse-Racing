using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VallaComportamiento : MonoBehaviour
{
    private Dictionary<GameObject, List<GameObject>> _vallasDetectadasPorCaballo;

    public static VallaComportamiento Instance {
        get;
        private set;
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _vallasDetectadasPorCaballo = new Dictionary<GameObject, List<GameObject>>();
    }

    void Update()
    {
        GameObject[] horses = GameObject.FindGameObjectsWithTag("Horse");
        GameObject[] vallas = GameObject.FindGameObjectsWithTag("Valla");

        foreach (var horse in horses)
        {
            if (!_vallasDetectadasPorCaballo.ContainsKey(horse))
            {
                _vallasDetectadasPorCaballo[horse] = new List<GameObject>();
            }

            foreach (var valla in vallas)
            {
                if (horse.transform.position.x > valla.transform.position.x &&
                    Mathf.Abs(horse.transform.position.y - valla.transform.position.y) <= 1.1f &&
                    !_vallasDetectadasPorCaballo[horse].Contains(valla))
                {
                    _vallasDetectadasPorCaballo[horse].Add(valla);
                    moverValla(valla, horse);
                }
            }
        }
    }

    public void moverValla(GameObject valla, GameObject horse) {
        if (horse.transform.position.x > -10) {
            valla.SetActive(false);
            return;
        }
        // Mueve la valla a una nueva posición y la reactiva
        valla.transform.position = new Vector3(horse.transform.position.x + 15, valla.transform.position.y, valla.transform.position.z);
        valla.SetActive(true);
        
        // Eliminar la valla de la lista de detectadas para permitir la nueva detección
        StartCoroutine(RemoveFromDetectedList(valla, horse));
    }

    private IEnumerator RemoveFromDetectedList(GameObject valla, GameObject horse) {
        yield return new WaitForSeconds(0.1f);
        if (_vallasDetectadasPorCaballo.ContainsKey(horse)) {
            _vallasDetectadasPorCaballo[horse].Remove(valla);
        }
    }
}
