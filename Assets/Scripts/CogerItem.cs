using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerItem : MonoBehaviour {

    public Item item;
    GameObject jugador;
    bool tengoItem = true;
    Inventario inventario;

    // Use this for initialization
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        inventario = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F) && tengoItem)
            {
                inventario.AñadirItem(item);
                tengoItem = false;
            }
        }
    }
}
