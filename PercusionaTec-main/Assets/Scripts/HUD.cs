using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script para funcionaiento del HUD para controlar menu de pausa.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
 */

public class HUD : MonoBehaviour
{

    public static HUD instance;


    private void Awake()
    {
        instance = this;

    }

    public void Salir()
    {
        SceneManager.LoadScene("Log-In");
        // Investigar como descargar la escena actual
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
        // Investigar como descargar la escena actual
    }

    public void Reanudar()
    {
        MenuPausa.instance.Pausar();
    }

}
