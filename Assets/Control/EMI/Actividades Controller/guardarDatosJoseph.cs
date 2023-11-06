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
        float valor1 = float.Parse(inputValor1.text);
        float valor2 = float.Parse(inputValor2.text);
        float valor3 = float.Parse(inputValor3.text);
        float valor4 = float.Parse(inputValor4.text);
        float valor5 = float.Parse(inputValor5.text);
        float valor6 = float.Parse(inputValor6.text);

        PlayerPrefs.SetFloat("Valor1", valor1);
        PlayerPrefs.SetFloat("Valor2", valor2);
        PlayerPrefs.SetFloat("Valor3", valor3);
        PlayerPrefs.SetFloat("Valor4", valor4);
        PlayerPrefs.SetFloat("Valor5", valor5);
        PlayerPrefs.SetFloat("Valor6", valor6);
        PlayerPrefs.Save();
    }
}
