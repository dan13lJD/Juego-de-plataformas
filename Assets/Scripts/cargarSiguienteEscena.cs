using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarSiguienteEscena : MonoBehaviour
{
    public string scene;
    public void siguienteNivel()
    {
        SceneManager.LoadScene(scene);
    }
}
