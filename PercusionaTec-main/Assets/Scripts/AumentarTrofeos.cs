using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script que obtiene numero de trofeos al terminar nivel para mostrar cada instrumento.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class AumentarTrofeos : MonoBehaviour
{
    public GameObject tambor;
    public GameObject congas;
    public GameObject maracas;


    public void Awake()
    {
        int trofeos = PlayerPrefs.GetInt("trofeo");
        switch (trofeos)
        {
            case 3:
                maracas.SetActive(true);
                congas.SetActive(true);
                tambor.SetActive(true);
                print("Maracas" + trofeos.ToString());
                break;
            case 2:
                maracas.SetActive(false);
                congas.SetActive(true);
                tambor.SetActive(true);
                print("Congas" + trofeos.ToString());
                break;
            case 1:
                maracas.SetActive(false);
                congas.SetActive(false);
                tambor.SetActive(true);
                print("Tambor" + trofeos.ToString());
                break;
            case 0:
                maracas.SetActive(false);
                congas.SetActive(false);
                tambor.SetActive(false);
                print("Nada");
                break;
        }
    }



}
