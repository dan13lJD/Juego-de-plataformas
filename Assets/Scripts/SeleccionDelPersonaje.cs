using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionDelPersonaje : MonoBehaviour
{

    public GameObject menuDeSeleccion;
    public GameObject personajeActivo;
    public GameObject destruirPersonaje1;
    public GameObject destruuirPersonaje2;
    public GameObject escenario;
    public GameObject HUD;

    public void ActivarEscenario()
    {
        HUD.gameObject.SetActive(true);
        menuDeSeleccion.gameObject.SetActive(false);
        personajeActivo.gameObject.SetActive(true);
        personajeActivo.transform.position = new Vector2(-3.683f,-2.088f);

        Object.Destroy(destruirPersonaje1);
        Object.Destroy(destruuirPersonaje2);
        escenario.gameObject.SetActive(true);
    }

}
