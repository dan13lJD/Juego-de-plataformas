using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirDaño : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //comprobamos si el jugador se ha entrado en la zona de colision del objeto
        if (collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("AddDamage", damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
