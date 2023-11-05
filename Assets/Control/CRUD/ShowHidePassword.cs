using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowHidePassword : MonoBehaviour
{
    public TMP_InputField passwordInput;
    public Toggle showHideToggle;

    void Start()
    {
        // Asegúrate de que los elementos necesarios estén asignados en el Inspector de Unity
        if (passwordInput == null || showHideToggle == null)
        {
            Debug.LogError("Asigna el InputField y el Toggle en el Inspector de Unity.");
            return;
        }

        // Agrega un listener al evento OnValueChanged del Toggle
        showHideToggle.onValueChanged.AddListener(ShowHidePasswordToggle);

        // Configura el campo de contraseña para que sea de tipo "Password" inicialmente
        passwordInput.inputType = TMP_InputField.InputType.Password;
    }

    void ShowHidePasswordToggle(bool showPassword)
    {
        // Cambia el tipo de contenido del campo de contraseña
        passwordInput.inputType = showPassword ? TMP_InputField.InputType.Standard : TMP_InputField.InputType.Password;

        // Forzar la actualización del campo de texto
        passwordInput.ForceLabelUpdate();
    }
}
