using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class botonpanelcorreo : MonoBehaviour
{
    ////public GameObject canvasRegistro;
    public GameObject canvasLogin;
    public GameObject panelMiraCorreo;
    //public GameObject registro;

    public TMP_InputField nameInput;
    public TMP_InputField lastNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField courseIdInput;

    //public TMP_InputField emailInput2;
    //public TMP_InputField passwordInput2;
    public Toggle aceptarToggle; // Agregado el Toggle

    void Start()
    {
        // Asegúrate de que solo uno de los Canvas esté activo al inicio
       

    }

    public void CambiarEntreCanvas()
    {
        // Cambia la visibilidad de los Canvas al presionar el botón
        canvasLogin.SetActive(true);
        panelMiraCorreo.SetActive(false);
        //registro.SetActive(false);
        nameInput.text = "";
        lastNameInput.text = "";
        emailInput.text = "";
        passwordInput.text = "";
        courseIdInput.text = "";

        //emailInput2.text = "";
        //passwordInput2.text = "";
        aceptarToggle.isOn = false; // Agregado
    }
}
