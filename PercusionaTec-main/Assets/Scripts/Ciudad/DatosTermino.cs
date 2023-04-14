using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que registra el tiempo en el que el jugador termina su partida.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class DatosTermino : MonoBehaviour
{
    public static DatosTermino instancia;
    public string HoraTermino;


    void Start()
    {

    }

    void Awake()
    {
        instancia = this;
    }

    void Update()
    {

    }
    public void GenerarHoraTermino()
    {
        HoraTermino = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
