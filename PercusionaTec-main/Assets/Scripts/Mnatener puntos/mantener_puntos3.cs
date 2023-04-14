using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mantener_puntos3 : MonoBehaviour
{
    public TextMeshProUGUI txtPuntos3;
    public TextMeshProUGUI txtErrores3;

    public int errores3;
    public int puntos3;
    // Start is called before the first frame update
    void Start()
    {
        errores3 = PlayerPrefs.GetInt("errores3");
        puntos3 = PlayerPrefs.GetInt("puntos3");
        txtPuntos3.text = puntos3.ToString();
        txtErrores3.text = errores3.ToString();
    }

  
}
