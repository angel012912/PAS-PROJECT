using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que registra el tiempo en el que el jugador termina su partida.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
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
