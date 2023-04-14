using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
 * Script que cambia a escenas especificas cuando se requiera.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class CambioEscena : MonoBehaviour
{
    //Cambia la escena una vex apretado el boton, el boton va a saber a que escena cambiar

    public void LoadScenePercusionatec()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void LoadSceneInicio()
    {
        SceneManager.LoadScene("ciudad");
    }
    public void LoadSceneSelecPerso()
    {
        SceneManager.LoadScene("Selec_personaje");
    }
    public void LoadSceneCreditos()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadSceneCiudad2()
    {
        SceneManager.LoadScene("ciudad 2");
    }

    public void LoadSceneCiudad3()
    {
        SceneManager.LoadScene("ciudad3");
    }

    public void LoadSceneCiudad4()
    {
        SceneManager.LoadScene("ciudad4");
    }
    public void LoadSceneOptions()
    {
        SceneManager.LoadScene("Setting");
    }

    public void LoadSceneConga()
    {
        SceneManager.LoadScene("ExplicacionConga");
    }

    public void LoadSceneXilofono()
    {
        SceneManager.LoadScene("ExplicacionXilofono");
    }

    public void LoadSceneMaracas()
    {
        SceneManager.LoadScene("ExplicacionMaracas");
    }

    public void LoadSceneTambor()
    {
        SceneManager.LoadScene("ExplicacionTambor");
    }

    public void LoadSceneNive1_Tambor()
    {
        SceneManager.LoadScene("Tambor");
        StartCoroutine(EnviarPartidaNivel(1));
    }

    public void LoadSceneNivel1_Conga()
    {
        SceneManager.LoadScene("Conga");
        StartCoroutine(EnviarPartidaNivel(2));
    }

    public void LoadSceneNivel1_Maracas()
    {
        SceneManager.LoadScene("Maracas");
        StartCoroutine(EnviarPartidaNivel(3));
    }

    public void LoadSceneLogin()
    {
        SceneManager.LoadScene("Log-In");
    }

    public void LoadSceneNivel1_Xilofono()
    {
        SceneManager.LoadScene("Xilofono");
        StartCoroutine(EnviarPartidaNivel(4));
    }

    public void LoadSceneTrofeo()
    {
        SceneManager.LoadScene("Trofeos");
    }

    public void LoadSceneTrofeo2()
    {
        SceneManager.LoadScene("Trofeo2");
    }

    public void LoadSceneTrofeo3()
    {
        SceneManager.LoadScene("Trofeo3");
    }

    public void LoadSceneTrofeo4()
    {
        SceneManager.LoadScene("Trofeo4");
    }

    public void Exit()
    {
       Application.Quit();
    }

    private IEnumerator EnviarPartidaNivel(int nivel)
    {
        //Buscar que no haya un Partida Nivel con ese id partida y nivel

        int puntaje = 0;
        string partida = PlayerPrefs.GetString("idPartida");

        WWWForm formaPartidaNivel = new WWWForm();
        formaPartidaNivel.AddField("partida", partida);
        formaPartidaNivel.AddField("nivel", nivel);
        formaPartidaNivel.AddField("puntaje", puntaje);
        string URLverificarPartNivel = "https://percusionatec-ge4wk.ondigitalocean.app/partida_nivel/" + partida+"/"+nivel;
        UnityWebRequest requestVerificar = UnityWebRequest.Get(URLverificarPartNivel);
        yield return requestVerificar.SendWebRequest();
        //Evalua que no haya un id part nivel ya ingresado 
        if(!(requestVerificar.result == UnityWebRequest.Result.Success))
        {
            string URLinsertarPartidaNivel = "https://percusionatec-ge4wk.ondigitalocean.app/partida_nivel";
            UnityWebRequest request = UnityWebRequest.Post(URLinsertarPartidaNivel, formaPartidaNivel);
            yield return request.SendWebRequest();
            //Se ingresa los datos de la partida nivel y se evalua que se haya ingresado 
            if (request.result == UnityWebRequest.Result.Success)
            {
                //Se obtiene el partida nivel
                string URLobtenerIdPartNivel = "https://percusionatec-ge4wk.ondigitalocean.app/partida_nivel/" + partida + "/" + nivel;
                UnityWebRequest requestIdPartNivel = UnityWebRequest.Get(URLobtenerIdPartNivel);
                yield return requestIdPartNivel.SendWebRequest();
                //Se obtiene el idPartidaNivel
                if (requestIdPartNivel.result == UnityWebRequest.Result.Success)
                { 
                    string id_partida_nivel = requestIdPartNivel.downloadHandler.text;
                    //Se guarda en el disco el valor de idPartida
                    PlayerPrefs.SetString("idPartidaNivel", id_partida_nivel);
                    PlayerPrefs.Save();
                }
            }
        }
        else
        {
            string id_partida_nivel = requestVerificar.downloadHandler.text;
            //Se guarda en el disco el valor de idPartida
            PlayerPrefs.SetString("idPartidaNivel", id_partida_nivel);
            PlayerPrefs.Save();
        }

        
    }
}
