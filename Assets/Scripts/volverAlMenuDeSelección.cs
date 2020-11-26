using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volverAlMenuDeSelección : MonoBehaviour
{
    public GameObject menuSeleccion;
    public GameObject menuAOcultar;
    
    public void volverAlMenuDeSeleccion()
    {
        menuSeleccion.gameObject.SetActive(true);
        menuAOcultar.gameObject.SetActive(false);        
    }
}
