using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Script que detecta la secuencia correcta
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */
public class cambionivelTAMBOR : MonoBehaviour
{
    public static cambionivelTAMBOR instance;

    

    public TextMeshProUGUI txtPuntos;
    public TextMeshProUGUI txtErrores;
   
    public int errores =  0;
    public int puntos = 0;

    public int i = 0;

    public string[] patron;

    private int AciertosMin = 14;

    void Start()
    {
       errores = PlayerPrefs.GetInt("errores");
        puntos = PlayerPrefs.GetInt("puntos");

        patron = new string[10];
        patron[0] = ("S");
        patron[1] = ("D");
        patron[2] = ("A");
        patron[3] = ("D");
        patron[4] = ("D");
        patron[5] = ("A");
        patron[6] = ("D");
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
                if (i > 6)
                {
                    PlayerPrefs.SetInt("puntos", puntos);
                    PlayerPrefs.SetInt("errores", errores);
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

        SceneManager.LoadScene("DRUMNivelExitoso");
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

        double score = ((double)AciertosMin / ((double)errores + (double)AciertosMin))*100;
        string scoreS = score.ToString();
        WWWForm formaScore = new WWWForm();
        formaScore.AddField("score", scoreS);

        string URLactScore = "https://percusionatec-ge4wk.ondigitalocean.app/partida_nivel/" + idPartNivel;
        UnityWebRequest requestActScore = UnityWebRequest.Post(URLactScore, formaScore);
        yield return requestActScore.SendWebRequest();
    }
}
