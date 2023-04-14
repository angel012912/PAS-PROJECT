using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Script que genera dialogo para finalizar nivel e incrementa en uno a numero de trofeos.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class DR2 : MonoBehaviour
{
    public TextMeshProUGUI texto;

    [TextArea(4, 40)]
    public string[] parrafos;
    int index = 0;
    public float velParrafo;

    public GameObject botonContinuar;
    public GameObject botonSalir;

    public GameObject panelDialogo;
    public GameObject botonLeer;

    public GameObject botonIncial;

    public int trofeo = 1;

    // Start is called before the first frame update
    void Start()
    {
        botonSalir.SetActive(false);
        botonLeer.SetActive(false);
        panelDialogo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator textoDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {
            texto.text += letra;
            yield return new WaitForSeconds(velParrafo);

        }
    }

    public void mostrarTexto()
    {
        texto.text += parrafos[index];
    }

    public void siguienteParrafo()
    {
        if (index < parrafos.Length - 1)
        {
            index++;
            texto.text = "";
            mostrarTexto();
            //StartCoroutine(textoDialogo());
        }
        else
        {
            texto.text = "Now you can continue to your adventure in the world of percussion!!!";
            botonContinuar.SetActive(false);
            botonSalir.SetActive(true);
        }
    }


    public void empezarDialogo()
    {
        botonLeer.SetActive(true);
        Time.timeScale = true ? 0 : 1;
        botonIncial.SetActive(false);
    }

    public void activarBotonLeer()
    {
        panelDialogo.SetActive(true);
        botonContinuar.SetActive(true);
        botonLeer.SetActive(false);
        mostrarTexto();
        //StartCoroutine(textoDialogo());
    }

    public void botonCerrar()
    {
        panelDialogo.SetActive(false);
        botonSalir.SetActive(false);
        index = 0;
        Time.timeScale = false ? 0 : 1;
        texto.text = "";
        botonIncial.SetActive(true);

    }

    public void sumarTrofeo()
    {
        trofeo++;
        PlayerPrefs.SetInt("trofeo", trofeo);
        print("Se sumó el trofeo" + trofeo.ToString());
        PlayerPrefs.Save();
    }
}
