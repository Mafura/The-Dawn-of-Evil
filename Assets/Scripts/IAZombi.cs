using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAZombi : MonoBehaviour {

    private NavMeshAgent agente;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        agente = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agente.destination = player.transform.position;
	}
}
