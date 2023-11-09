using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CambiarCanvas : MonoBehaviour
{
    public GameObject canvasRegistro;
    public GameObject canvasLogin;

    public TMP_InputField nameInput;
    public TMP_InputField lastNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField courseIdInput;

    public TMP_InputField emailInput2;
    public TMP_InputField passwordInput2;
    public Toggle aceptarToggle; // Agregado el Toggle

    void Start()
    {
        // Aseg�rate de que solo uno de los Canvas est� activo al inicio
        canvasRegistro.SetActive(false);
        canvasLogin.SetActive(true);

    }

    public void CambiarEntreCanvas()
    {
        // Cambia la visibilidad de los Canvas al presionar el bot�n
        canvasRegistro.SetActive(!canvasRegistro.activeSelf);
        canvasLogin.SetActive(!canvasLogin.activeSelf);
        nameInput.text = "";
        lastNameInput.text = "";
        emailInput.text = "";
        passwordInput.text = "";
        courseIdInput.text = "";

        emailInput2.text = "";
        passwordInput2.text = "";
        aceptarToggle.isOn = false; // Agregado
    }
}
