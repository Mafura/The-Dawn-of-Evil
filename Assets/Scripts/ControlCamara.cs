using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour {

    private static List<Camera> camaras;

	// Use this for initialization
	void Start () {
        GameObject[] auxcamaras = GameObject.FindGameObjectsWithTag("MainCamera");
        Debug.Log(auxcamaras.Length);

        camaras = new List<Camera>();

        for (int i = 0; i < auxcamaras.Length; i++)
        {
            Debug.Log(auxcamaras[i].GetComponent<Camera>().name);
            camaras.Add(auxcamaras[i].GetComponent<Camera>());
            //camaras.Add(auxcamaras[i]);
        }
	}
	
	public static void CambiarCamara(Camera camara)
    {
        foreach (Camera c in camaras)
        {
            c.enabled = false;
        }
        camara.enabled = true;
    }
}
