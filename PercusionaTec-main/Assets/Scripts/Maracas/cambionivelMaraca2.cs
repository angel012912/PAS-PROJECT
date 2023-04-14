using UnityEngine.Networking;
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
public class cambionivelMaraca2 : MonoBehaviour
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
        errores = PlayerPrefs.GetInt("errores3");
        puntos = PlayerPrefs.GetInt("puntos3");

        patron = new string[10];
        patron[0] = ("S");
        patron[1] = ("U");
        patron[2] = ("W");
        patron[3] = ("U");
        patron[4] = ("U");
        patron[5] = ("W");
        patron[6] = ("W");
        patron[7] = ("U");
        patron[8] = ("W");
        txtPuntos.text = puntos.ToString();
        txtErrores.text = errores.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (patron[i] == "U")
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
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (patron[i] == "W")
            {
                puntos = puntos + 1;
                txtPuntos.text = puntos.ToString();
                i = i + 1;
                if (i > 8)
                {
                    PlayerPrefs.SetInt("puntos3", puntos);
                    PlayerPrefs.SetInt("errores3", errores);
                    PlayerPrefs.Save(); // Escribe en Disco     
                    StartCoroutine(RegistroIntento());
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

        SceneManager.LoadScene("CompletadosNiveles");
    }
    private IEnumerator RegistroIntento()
    {
        //Se registra el intento de tambor
        string inicio = PlayerPrefs.GetString("inicio_intento");
        string idPartNivel = PlayerPrefs.GetString("idPartidaNivel");
        string final = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        WWWForm formaRegistraIntento = new WWWForm();
        formaRegistraIntento.AddField("inicio", inicio);
        formaRegistraIntento.AddField("final", final);
        formaRegistraIntento.AddField("idPartNivel", idPartNivel);
        formaRegistraIntento.AddField("errores", errores);

        string URLRegistroIntento = "https://percusionatec-ge4wk.ondigitalocean.app/partida_nivel_intento";
        UnityWebRequest requestRegistroIntento = UnityWebRequest.Post(URLRegistroIntento, formaRegistraIntento);
        yield return requestRegistroIntento.SendWebRequest();
    }
}
