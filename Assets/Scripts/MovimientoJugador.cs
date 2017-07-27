using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {
    private float valorMovimiento;
    private float valorRotación;
    public float velocidad = 6.5f;
    public float velocidadRotacion = 100f;
    private Rigidbody j_rigidbody;

    private void Awake()
    {
        j_rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        valorMovimiento = Input.GetAxis("Vertical");
        valorRotación = Input.GetAxis("Horizontal");
	}

    private void OnEnable()
    {
        j_rigidbody.isKinematic = false;
        valorMovimiento = 0f;
        valorRotación = 0f;
    }

    private void FixedUpdate()
    {
        Mover();
        Girar();
    }

    private void Mover()
    {
        if(valorMovimiento < 0f)
        {
            Vector3 movimiento = transform.forward * valorMovimiento/1.5f * velocidad * Time.deltaTime;
            j_rigidbody.MovePosition(j_rigidbody.position + movimiento);
        }
        else
        {
            Vector3 movimiento = transform.forward * valorMovimiento * velocidad * Time.deltaTime;
            j_rigidbody.MovePosition(j_rigidbody.position + movimiento);
        }      
    }

    private void Girar()
    {
        if(valorMovimiento == 0f)
        {
            float girar = valorRotación * velocidadRotacion * Time.deltaTime;
            Quaternion giroRotación = Quaternion.Euler(0f, girar, 0f);
            j_rigidbody.MoveRotation(j_rigidbody.rotation * giroRotación);
        }
        else
        {
            float girar = valorRotación * velocidadRotacion/3 * Time.deltaTime;
            Quaternion giroRotación = Quaternion.Euler(0f, girar, 0f);
            j_rigidbody.MoveRotation(j_rigidbody.rotation * giroRotación);
        }
    }
}
