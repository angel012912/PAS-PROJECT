using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que obtiene la eleccion de personaje establecida por el jugador.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
 */

public class ElegirPersonaje : MonoBehaviour
{
    public int eleccion;
    public static ElegirPersonaje instancia;
    public void Awake()
    {
        instancia = this;
    }

    public void EstablecerEleccion(string nombrePersonaje)
    {
        if (nombrePersonaje == "chica")
        {
            eleccion = 1;
        }
        else if (nombrePersonaje == "dino")
        {
            eleccion = 2;
        }
        else 
        {
            eleccion = 3;
        }
        PlayerPrefs.SetInt("eleccion", eleccion);
    }

}
