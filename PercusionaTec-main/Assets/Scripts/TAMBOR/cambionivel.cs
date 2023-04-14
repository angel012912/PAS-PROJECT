using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Script que detecta la secuencia correcta del tambor
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */
public class cambionivel : MonoBehaviour
{
    

    public int errores = 0;
    public int puntos = 0;

    public TextMeshProUGUI txtPuntos;
    public TextMeshProUGUI txtErrores;

    //Se guarda el tiempo en que inicia el intento
    public string inicio;

    public int i = 0;

    public string[] patron;


    void Start()
    {


        patron = new string[10];
        patron[0] = ("S");
        patron[1] = ("A");
        patron[2] = ("D");
        patron[3] = ("A");
        patron[4] = ("D");
        patron[5] = ("A");
        patron[6] = ("D");
        patron[7] = ("A");
        patron[8] = ("D");
        PlayerPrefs.SetInt("puntos", puntos);
        PlayerPrefs.SetInt("errores", errores);
        txtPuntos.text = puntos.ToString();
        txtErrores.text = errores.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (patron[i] == "A")
            {
                puntos = puntos + 1;
                txtPuntos.text = puntos.ToString();
                i = i + 1;
            }
            else
            {
                errores = errores + 1;
                txtErrores.text = errores.ToString();
            }

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (patron[i] == "D")
            {
                puntos = puntos + 1;
                txtPuntos.text = puntos.ToString();
                i = i + 1;
                if (i > 8)
                {
                    PlayerPrefs.SetInt("puntos", puntos);
                    PlayerPrefs.SetInt("errores", errores);
                    PlayerPrefs.Save(); // Escribe en Disco     
                    esperarscene();
                }

            }
            else
            {
                errores = errores + 1;
                txtErrores.text = errores.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (patron[i] == "S")
            {
                i = i + 1;
                inicio = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                PlayerPrefs.SetString("inicio_intento", inicio);
                PlayerPrefs.Save();
            }
        }

    }

    void esperarscene()
    {
        StartCoroutine(next_scene());
    }

    private IEnumerator next_scene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Tambor2");
    }
}
