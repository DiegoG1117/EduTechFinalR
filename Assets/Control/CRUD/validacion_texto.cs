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
        // Puedes agregar lógica de inicio aquí si es necesario
    }

    public void Validate()
    {
        string correoIngresado = inputField.text;

        if (correoIngresado.Length < 3)
        {
            resultadoTexto.text = "Mínimo 3 caracteres";
            resultadoTexto.color = Color.red;
        }
        else if (correoIngresado.EndsWith("@uao.edu.co"))
        {
            resultadoTexto.text = "Correo válido";
            resultadoTexto.color = Color.green;
        }
        else
        {
            resultadoTexto.text = "Correo inválido";
            resultadoTexto.color = Color.red;
        }
    }
}
