using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/*
 * Script que registra el tiempo en el que el jugador empieza su partida.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
 */

public class CiudadDatos : MonoBehaviour
{
    public static CiudadDatos instancia;
    public string tiempoConecta;

    //"MM/dd/yyyy HH:mm"
    // Start is called before the first frame update
    void Start()
    {
        tiempoConecta = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    void Awake()
    {
        instancia = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
