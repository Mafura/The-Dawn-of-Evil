using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCamara : MonoBehaviour {

    private Camera miCamara;

    private void Start()
    {
        miCamara = gameObject.GetComponentInChildren<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(miCamara.name);
            ControlCamara.CambiarCamara(miCamara);
        }
    }
}
