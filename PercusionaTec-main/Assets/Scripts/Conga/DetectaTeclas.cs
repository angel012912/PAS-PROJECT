using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 * Script que detecta la secuencia correcta del tambor
 * Autores: Erika Marlene Garc?a S?nchez, C?sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos? Luis Madrigal S?nchez
 */
public class DetectaTeclas : MonoBehaviour
{


    public int errores = 0;
    public int puntos = 0;

    public TextMeshProUGUI txtPuntos;
    public TextMeshProUGUI txtErrores;


    public int i = 0;

    public string[] patron;


    void Start()
    {


        patron = new string[10];
        patron[0] = ("S");
        patron[1] = ("Z");
        patron[2] = ("Z");
        patron[3] = ("Z");
        patron[4] = ("M");
        patron[5] = ("Z");
        patron[6] = ("M");
        patron[7] = ("Z");
        //PlayerPrefs.SetInt("puntos2", puntos);
        //PlayerPrefs.SetInt("errores2", errores);
        txtPuntos.text = puntos.ToString();
        txtErrores.text = errores.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (patron[i] == "Z")
            {
                puntos = puntos + 1;
                txtPuntos.text = puntos.ToString();
                i = i + 1;
                if (i > 7)
                {
                    PlayerPrefs.SetInt("puntos2", puntos);
                    PlayerPrefs.SetInt("errores2", errores);
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
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (patron[i] == "M")
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
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (patron[i] == "S")
            {
                i = i + 1;
                string inicio = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        SceneManager.LoadScene("Conga2");
    }

}

