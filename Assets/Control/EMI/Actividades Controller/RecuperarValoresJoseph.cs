using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecuperarValoresJoseph : MonoBehaviour
{
    [SerializeField] TMP_Text textoResultado;
    [SerializeField] TMP_Text textoResultado1;
    [SerializeField] TMP_Text textoResultado2;

    public Button botonRepetir;
    public Button botonRepetir1;
    public Button botonRepetir2;

    [SerializeField] TMP_Text textoVelocidad1;
    [SerializeField] TMP_Text textoAngulo1;
    [SerializeField] TMP_Text textoVelocidad2;
    [SerializeField] TMP_Text textoAngulo2;
    [SerializeField] TMP_Text textoVelocidad3;
    [SerializeField] TMP_Text textoAngulo3;

    void Start()
    {
        MostrarResultados();
    }

    void MostrarResultados()
    {
        if (PlayerPrefs.HasKey("Valor1") && PlayerPrefs.HasKey("Valor2") &&
            PlayerPrefs.HasKey("Valor3") && PlayerPrefs.HasKey("Valor4") &&
            PlayerPrefs.HasKey("Valor5") && PlayerPrefs.HasKey("Valor6"))
        {
            int valor1 = PlayerPrefs.GetInt("Valor1");
            int valor2 = PlayerPrefs.GetInt("Valor2");
            int valor3 = PlayerPrefs.GetInt("Valor3");
            int valor4 = PlayerPrefs.GetInt("Valor4");
            int valor5 = PlayerPrefs.GetInt("Valor5");
            int valor6 = PlayerPrefs.GetInt("Valor6");

            bool exitoso1 = valor1 == 1 && valor2 == 1;
            bool exitoso2 = valor3 == 1 && valor4 == 1;
            bool exitoso3 = valor5 == 1 && valor6 == 1;

            if (exitoso1)
            {
                textoResultado.text = "Exitoso";
                textoResultado.color = Color.green;
                botonRepetir.gameObject.SetActive(false); // Desactiva el botón
            }
            else
            {
                textoResultado.text = "Fallido";
                textoResultado.color = Color.red;
                botonRepetir.gameObject.SetActive(true); // Activa el botón
            }
            if (exitoso2)
            {
                textoResultado1.text = "Exitoso";
                textoResultado1.color = Color.green;
                botonRepetir1.gameObject.SetActive(false); // Activa el botón
            }
            else
            {
                textoResultado1.text = "Fallido";
                textoResultado1.color = Color.red;
                botonRepetir1.gameObject.SetActive(true); // Activa el botón
            }
            if (exitoso3)
            {
                textoResultado2.text = "Exitoso";
                textoResultado2.color = Color.green;
                botonRepetir2.gameObject.SetActive(false); // Activa el botón
            }
            else
            {
                // Si alguno de los tiros es fallido, muestra "Fallido" en rojo
                
                
                textoResultado2.text = "Fallido";
                textoResultado2.color = Color.red;
                botonRepetir2.gameObject.SetActive(true); // Activa el botón
            }


            // Muestra los valores recuperados
            MostrarValores("Velocidad : ", valor1, "Ángulo : ", valor2, textoVelocidad1, textoAngulo1);
            MostrarValores("Velocidad : ", valor3, "Ángulo : ", valor4, textoVelocidad2, textoAngulo2);
            MostrarValores("Velocidad : ", valor5, "Ángulo : ", valor6, textoVelocidad3, textoAngulo3);
        }

    }

    void MostrarResultado(TMP_Text texto, string mensaje, Color color)
    {
        texto.text = mensaje;
        texto.color = color;
    }

    void MostrarValores(string prefixVelocidad, int velocidad, string prefixAngulo, int angulo, TMP_Text textoVelocidad, TMP_Text textoAngulo)
    {
        textoVelocidad.text = prefixVelocidad + velocidad + " m/s";
        textoAngulo.text = prefixAngulo + angulo + "°";
    }
}
