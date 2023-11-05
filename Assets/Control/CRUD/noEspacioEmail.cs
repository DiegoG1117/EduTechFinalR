using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class noEspacioEmail : MonoBehaviour
{
    public TMP_InputField emailInput;

    void Start()
    {
        // Aseg�rate de que los elementos necesarios est�n asignados en el Inspector de Unity
        if (emailInput == null)
        {
            Debug.LogError("Asigna el InputField en el Inspector de Unity.");
            return;
        }

        // Agrega un listener al evento OnValueChanged del InputField para validar la entrada
        emailInput.onValueChanged.AddListener(ValidatePasswordInput);
    }

    void ValidatePasswordInput(string input)
    {
        // Elimina espacios en blanco del texto de la contrase�a
        emailInput.text = input.Replace(" ", "");
    }
}
