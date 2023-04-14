using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para pausar escenas en el juego.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
 */

public class MenuPausa : MonoBehaviour
{

    [SerializeField]
    private GameObject panelPausa;
    public bool estaPausado = false;

    public static MenuPausa instance;
    private void Awake()
    {
        instance = this;
    }



    public void Pausar()
    {
        estaPausado = !estaPausado;
        panelPausa.SetActive(estaPausado);
        Time.timeScale = estaPausado ? 0 : 1;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }



}
   

  

