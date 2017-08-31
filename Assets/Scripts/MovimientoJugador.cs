using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {
    private float valorMovimiento;
    private float valorRotación;
    public float velocidad;
    private float velocidadCorrer;
    public float velocidadRotacion;
    private float velocidadMovimiento;
    private float rotaciónInicial;
    private float rotaciónFinal;
    private Rigidbody j_rigidbody;
    private bool rotando = false;
    public bool bloquearMovimiento = false;
    private Quaternion rotación;
    private Quaternion final;
    public GameObject bala;

    private void Awake()
    {
        j_rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        velocidadCorrer = velocidad * 1.5f;
        velocidadMovimiento = velocidad;
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
        if (!bloquearMovimiento)
        {
            Mover();
            Girar();
            Giro180();
        }
        
        //Apuntar();
    }

    private void Mover()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadMovimiento = velocidadCorrer;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadMovimiento = velocidad;
        }
        if(valorMovimiento < 0f)
        {
            Vector3 movimiento = transform.forward * valorMovimiento/1.5f * velocidadMovimiento * Time.deltaTime;
            j_rigidbody.MovePosition(j_rigidbody.position + movimiento);
        }
        else
        {
            Vector3 movimiento = transform.forward * valorMovimiento * velocidadMovimiento * Time.deltaTime;
            j_rigidbody.MovePosition(j_rigidbody.position + movimiento);
        }      
    }

    private void Giro180()
    {
        //Debug.Log(transform.rotation.y);
        //Debug.Log(final.y);
        if (Input.GetKeyDown(KeyCode.Space) && valorMovimiento < 0f && !rotando)
        {
            rotando = true;
            rotaciónInicial = j_rigidbody.rotation.y;
            rotaciónFinal = j_rigidbody.rotation.y + 180f;
            final = Quaternion.LookRotation(-transform.forward, Vector3.up);
            //Debug.Log("giro180");
        }
        if (rotando)
        {
            //transform.rotation = final;
            transform.rotation = Quaternion.Slerp(transform.rotation, final, 5f * Time.deltaTime); 
        }
        if (transform.rotation.y == final.y) { 
            rotando = false;
        }
    }

    private void Apuntar()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Disparar();
            }
        }
    }

    private void Disparar()
    {
        Transform transformSpawn = GameObject.FindGameObjectWithTag("SpawnBala").transform;
        Vector3 posición = new Vector3(transformSpawn.position.x, transformSpawn.position.y, transformSpawn.position.z);
        GameObject balaDisparada = Instantiate(bala, posición, transformSpawn.rotation);
        balaDisparada.GetComponent<BalaDisparada>().enabled = true;
    }

    private void Girar()
    {
        //Debug.Log("giro");
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
