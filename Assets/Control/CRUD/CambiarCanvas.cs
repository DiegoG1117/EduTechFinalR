using UnityEngine;

public class CambiarCanvas : MonoBehaviour
{
    public GameObject canvasRegistro;
    public GameObject canvasLogin;

    void Start()
    {
        // Asegúrate de que solo uno de los Canvas esté activo al inicio
        canvasRegistro.SetActive(false);
        canvasLogin.SetActive(true);
    }

    public void CambiarEntreCanvas()
    {
        // Cambia la visibilidad de los Canvas al presionar el botón
        canvasRegistro.SetActive(!canvasRegistro.activeSelf);
        canvasLogin.SetActive(!canvasLogin.activeSelf);
    }
}
