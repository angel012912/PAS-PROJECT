using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Script que detecta la secuencia correcta del tambor
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */
public class DetectaTeclas2 : MonoBehaviour
{

    public int errores = 0;
    public int puntos = 0;

    public TextMeshProUGUI txtPuntos;
    public TextMeshProUGUI txtErrores;


    public int i = 0;

    public string[] patron;


    void Start()
    {


        patron = new string[9];
        patron[0] = ("S");
        patron[1] = ("M");
        patron[2] = ("Z");
        patron[3] = ("M");
        patron[4] = ("M");
        patron[5] = ("Z");
        patron[6] = ("M");
        patron[7] = ("Z");
        patron[8] = ("M");
        puntos = PlayerPrefs.GetInt("puntos2");
        errores = PlayerPrefs.GetInt("errores2");
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
                if (i > 8)
                {
                    PlayerPrefs.SetInt("puntos2", puntos);
                    PlayerPrefs.SetInt("errores2", errores);
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

        SceneManager.LoadScene("CongaNivelExitoso");
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

