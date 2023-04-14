using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

// Autores: Jose Luis Madrigal, Erika Marlene Garcia, Cesar Emiliano Palome, Jose Angel Garcia
// Clase para hacer conexion web con unity para mandar datos igresados en login 

public class Login : MonoBehaviour
{
    public TextMeshProUGUI resultado;



    //Los datos de entrada
    public TMP_InputField textoUsuario;
    public TMP_InputField textoContrasena;

    //Enviar los datos al servidor(click del boton)
    public void EnviarDatos()
    {
        StartCoroutine(SubirDatos());
    }

    private IEnumerator SubirDatos()
    {
        //Recuperar los datos
        string usuario = textoUsuario.text;
        string contrasena = textoContrasena.text;
        //Crear un objeto con los datos
        WWWForm forma = new WWWForm();
        forma.AddField("usuario", usuario);
        forma.AddField("contrasena", contrasena);
        string URLinicioSesion = "https://percusionatec-ge4wk.ondigitalocean.app/jugador/" + usuario + "/" + contrasena;
        UnityWebRequest request = UnityWebRequest.Get(URLinicioSesion);
        yield return request.SendWebRequest();
        //....despues de cierto tiempo
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Se guarda el id del usuario que ingresó
            string id_usuario = request.downloadHandler.text; ;
            PlayerPrefs.SetString("usuario", id_usuario);
            PlayerPrefs.Save();
            
            //Se guarda la hora en que el log in fue aceptado
            string tiempoConecta = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            PlayerPrefs.SetString("hora_conecta_partida", tiempoConecta);
            PlayerPrefs.Save();

            //Mandar los datos de cuando se conecta y usuario
            WWWForm formaConecta = new WWWForm();
            formaConecta.AddField("usuarioConecta", usuario);
            formaConecta.AddField("tiempoConecta", tiempoConecta);

            string URLDatosConectaPartida = "https://percusionatec-ge4wk.ondigitalocean.app/partidas";
            UnityWebRequest requestConecta = UnityWebRequest.Post(URLDatosConectaPartida,formaConecta);
            yield return requestConecta.SendWebRequest();
            if (requestConecta.result == UnityWebRequest.Result.Success)
            {
                //Se requiere obtener el Id partida que se ingresó
                string URLIdPartida = "https://percusionatec-ge4wk.ondigitalocean.app/partidas/" + usuario + "/" + tiempoConecta;
                UnityWebRequest requestIdPartida = UnityWebRequest.Get(URLIdPartida);
                yield return requestIdPartida.SendWebRequest();
                if (requestIdPartida.result == UnityWebRequest.Result.Success)
                {
                    string id_partida = requestIdPartida.downloadHandler.text;
                    PlayerPrefs.SetString("idPartida", id_partida);
                    PlayerPrefs.Save();
                }
                    SceneManager.LoadScene("Inicio");
            }
        }
        else
        {
            resultado.text = "Error: El usuario no esta ingresado o la contraseña es incorrecta";
        }
    }

    public void registrar()
    {
        SceneManager.LoadScene("RegistroDatos");
        // Investigar como descargar la escena actual
    }
}
