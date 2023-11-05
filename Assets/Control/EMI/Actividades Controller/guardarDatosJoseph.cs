using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class guardarDatosJoseph : MonoBehaviour
{
    public TMP_InputField inputValor1;
    public TMP_InputField inputValor2;
    public TMP_InputField inputValor3;
    public TMP_InputField inputValor4;
    public TMP_InputField inputValor5;
    public TMP_InputField inputValor6;

    public Button guardarButton;  // Asigna este botón desde el inspector

    private void Start()
    {
        // Asocia el método GuardarDatos() al evento de clic del botón
        guardarButton.onClick.AddListener(GuardarDatos);
    }

    public void GuardarDatos()
    {
        int valor1 = int.Parse(inputValor1.text);
        int valor2 = int.Parse(inputValor2.text);
        int valor3 = int.Parse(inputValor3.text);
        int valor4 = int.Parse(inputValor4.text);
        int valor5 = int.Parse(inputValor5.text);
        int valor6 = int.Parse(inputValor6.text);

        PlayerPrefs.SetInt("Valor1", valor1);
        PlayerPrefs.SetInt("Valor2", valor2);
        PlayerPrefs.SetInt("Valor3", valor3);
        PlayerPrefs.SetInt("Valor4", valor4);
        PlayerPrefs.SetInt("Valor5", valor5);
        PlayerPrefs.SetInt("Valor6", valor6);
        PlayerPrefs.Save();
    }
}
