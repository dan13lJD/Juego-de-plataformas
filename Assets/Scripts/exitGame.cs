using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class exitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Has salido del juego");
    }    
}
