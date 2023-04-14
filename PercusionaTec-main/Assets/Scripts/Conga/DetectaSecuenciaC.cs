using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 * Script que detecta la secuencia correcta de la Conga
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */
public class DetectaSecuenciaC : MonoBehaviour
{
    

    public int errores = 0;
    public int puntos = 0;

    public TextMeshProUGUI txtPuntos;
    public TextMeshProUGUI txtErrores;


    public int i = 0;

    public string[] patron;


    void Start()
    {

        /*Z, M*/
        patron = new string[10];
        patron[0] = ("S");
        patron[1] = ("A");
        patron[2] = ("D");
        patron[3] = ("A");
        patron[4] = ("D");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (patron[i] == "D")
            {
                puntos = puntos + 1;
                txtPuntos.text = puntos.ToString();
                i = i + 1;
                if (i > 4)
                {
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
            }
        }

    }

    void esperarscene()
    {
        StartCoroutine(next_scene2());
    }

    private IEnumerator next_scene2()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("NivelExitoso");
    }
}
