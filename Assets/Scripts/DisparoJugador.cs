using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour {
    public Rigidbody bala_r;
    public Transform spawnBala;
    public float fuerzaDisparo;

    private string botónDisparo;
    private bool disparado;

	// Use this for initialization
	void Start () {
        botónDisparo = "Fire1";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.F))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Disparar();
            }
        }
	}

    private void Disparar()
    {
        disparado = true;

        Rigidbody instanciaBala = Instantiate(bala_r, spawnBala.position, spawnBala.rotation) as Rigidbody;

        instanciaBala.velocity = fuerzaDisparo * spawnBala.forward;
        Debug.Log("fuego");
    }
}
