using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeerTexto : MonoBehaviour {
    Text hijo;
    Text texto;
    bool leyendo = false;
    GameObject jugador;

	// Use this for initialization
	void Start () {
        hijo = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        texto = GameObject.FindGameObjectWithTag("ScreenText").GetComponent<Text>();
        jugador = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(hijo.text);
        if (Input.GetKeyDown(KeyCode.E) && !leyendo)
        {
            jugador.GetComponent<MovimientoJugador>().bloquearMovimiento = true;
            //texto.enabled = true;
            texto.text = hijo.text;
            leyendo = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && leyendo)
        {
            jugador.GetComponent<MovimientoJugador>().bloquearMovimiento = false;
            //texto.enabled = false;
            texto.text = "";
            leyendo = false;
        }
    }
}
