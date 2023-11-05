using UnityEngine;

public class CambiarCanvas : MonoBehaviour
{
    public GameObject canvasRegistro;
    public GameObject canvasLogin;

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
    }
}
