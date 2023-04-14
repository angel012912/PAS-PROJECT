using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mantener_puntos : MonoBehaviour
{
    public TextMeshProUGUI txtPuntos;
    public TextMeshProUGUI txtErrores;

    public int errores;
    public int puntos;

    void Start()
    {
        errores = PlayerPrefs.GetInt("errores");
        puntos = PlayerPrefs.GetInt("puntos");
        txtPuntos.text = puntos.ToString();
        txtErrores.text = errores.ToString();
    }



}
