﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPersonaje : MonoBehaviour
{
    //variables para la salud del personaje
    public int totalHealth = 3;
    private int health;
    private SpriteRenderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    public void AddDamage(int amount)
    {
        //este método agrega daño al personaje
        health = health - amount;
        //llamada a la corutina para que el personaje cambie de color
        StartCoroutine("VisualFeedback");
        //juego terminado
        if (health <= 0)
        {
            //esta asignacion se hace para que la variable 
            //de salud no sea un numero negativo
            //si se baja de 0 entonces se asigna la salud a 0
            health = 0;
        }

        Debug.Log("El jugador ha recibido daño, su salud actual es: " + health);
    }


    private IEnumerator VisualFeedback()
    {
        //esta corutina cambia  el color del personaje a rojo
        //por un segundo, cuando este recibe daño
        //despues lo regresa al color original.
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.color = Color.white;
    }
}
