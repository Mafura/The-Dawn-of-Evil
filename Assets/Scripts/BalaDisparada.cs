using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDisparada : MonoBehaviour {
    public int rango;
    public int velocidad;
    public GameObject jugador;
    private Transform posInicial;
    private Quaternion rotacion;
    //public Transform rotaciónBala;

	// Use this for initialization
	void Awake() {
        jugador = GameObject.FindGameObjectWithTag("Player");
        posInicial = jugador.transform;
        rotacion = jugador.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        float distancia = Vector3.Distance(posInicial.position, transform.position);
        float move = velocidad * Time.deltaTime;
        transform.Translate(transform.forward * move);
        if(distancia >= rango)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
