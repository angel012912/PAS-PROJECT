using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mantenererrores : MonoBehaviour
{

    public TextMeshProUGUI txtPuntos2;
    public TextMeshProUGUI txtErrores2;

    public int errores2;
    public int puntos2;

    // Start is called before the first frame update
    void Start()
    {
        
        errores2 = PlayerPrefs.GetInt("errores2");
        puntos2 = PlayerPrefs.GetInt("puntos2");
        txtPuntos2.text = puntos2.ToString();
        txtErrores2.text = errores2.ToString();

        
    }
}
