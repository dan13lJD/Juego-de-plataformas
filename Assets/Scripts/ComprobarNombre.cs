using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprobarNombre : MonoBehaviour
{
    public InputField nickname;
    public GameObject nicknameVacio;
    public GameObject menuDeSeleccion;
    public GameObject seleccionDeNombre;

    public void comprobarNombre()
    {
        //comprobamos que el texto no sea igual a 0
        if(nickname.text.Length <= 0)
        {
            //si el texto es menor a 0, entonces se muestra una pantalla de error
            nicknameVacio.gameObject.SetActive(true);
            menuDeSeleccion.gameObject.SetActive(false);
            seleccionDeNombre.gameObject.SetActive(true);
            Debug.Log("No se ha ingresado texto...");
            Debug.Log("tamaño del texto = "+nickname.text.Length);
        }
        else
        {
            //si es mayor a 0 entonces se oculta la pantalla del nickname y se muestra la pantalla de seleccion del personaje
            seleccionDeNombre.gameObject.SetActive(false);
            menuDeSeleccion.gameObject.SetActive(true);
            Debug.Log("El nombre del jugador es: " + nickname.text);
            Debug.Log("tamaño del texto: " + nickname.text.Length);

        }
    }

}
