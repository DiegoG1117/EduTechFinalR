using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class validacion_texto : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text resultadoTexto;

    void Start()
    {
        // Puedes agregar l�gica de inicio aqu� si es necesario
    }

    public void Validate()
    {
        string correoIngresado = inputField.text;

        if (correoIngresado.Length < 3)
        {
            resultadoTexto.text = "M�nimo 3 caracteres";
            resultadoTexto.color = Color.red;
        }
        else if (correoIngresado.EndsWith("@uao.edu.co"))
        {
            resultadoTexto.text = "Correo v�lido";
            resultadoTexto.color = Color.green;
        }
        else
        {
            resultadoTexto.text = "Correo inv�lido";
            resultadoTexto.color = Color.red;
        }
    }
}
