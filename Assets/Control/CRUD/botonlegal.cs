using UnityEngine;

public class botonlegal : MonoBehaviour
{
    public GameObject panel;
    public UnityEngine.UI.Button botonAbrirPanel;
    public UnityEngine.UI.Button botonCerrarPanel;

    void Start()
    {
        // Desactivar el panel al inicio
        if (panel != null)
        {
            panel.SetActive(false);
        }

        // Asignar funciones a los botones
        if (botonAbrirPanel != null)
        {
            botonAbrirPanel.onClick.AddListener(AbrirPanel);
        }

        if (botonCerrarPanel != null)
        {
            botonCerrarPanel.onClick.AddListener(CerrarPanel);
        }
    }

    void AbrirPanel()
    {
        // Activar el panel al presionar el botón "Términos y Condiciones"
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    void CerrarPanel()
    {
        // Desactivar el panel al presionar el botón "Cerrar"
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
