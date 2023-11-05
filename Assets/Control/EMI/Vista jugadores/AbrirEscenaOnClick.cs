using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Agregado para usar el componente Button

public class AbrirEscenaOnClick : MonoBehaviour
{
    public Button boton; // Agregado para referenciar el botón en el Inspector

    void Start()
    {
        // Asignar la función de cambio de escena al evento de clic del botón
        if (boton != null)
        {
            boton.onClick.AddListener(CambioEscena);
        }
    }

    void CambioEscena()
    {
        // Cargar la escena cuando se hace clic en el botón
        SceneManager.LoadScene("EscenaPractica");
    }
}
