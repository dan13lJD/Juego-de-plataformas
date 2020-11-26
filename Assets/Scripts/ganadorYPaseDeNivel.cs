using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class ganadorYPaseDeNivel : MonoBehaviour
{
    public GameObject pantallaGanador;
    public GameObject ocultarObjetos;
    public Image ganador;
    private SpriteRenderer _renderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        //comprobamos si el jugador se ha entrado en la zona de colision del objeto
        if (collision.CompareTag("Player"))
        {
            _renderer = GetComponent<SpriteRenderer>();
            //ganador = _renderer.sprite;
            Debug.Log(_renderer.sprite);
            pantallaGanador.gameObject.SetActive(true);
            ocultarObjetos.gameObject.SetActive(false);
            Debug.Log("Creo que tenemos un ganador :O");            
        }
    }
}
