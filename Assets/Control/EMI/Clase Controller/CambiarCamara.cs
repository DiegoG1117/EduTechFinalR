using UnityEngine;

public class CambiarCamara : MonoBehaviour
{
    public Camera camaraNormal;
    public Camera camaraZoom;
    public GameObject botonZoom;
    public GameObject botonVistaNormal;


    void Start()
    {
        // Desactivar la cámara de zoom al inicio
        if (camaraZoom != null)
        {
            camaraZoom.gameObject.SetActive(false);
        }

        // Asignar funciones a los botones
        if (botonZoom != null)
        {
            botonZoom.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CambiarACamaraZoom);
        }

        if (botonVistaNormal != null)
        {
            botonVistaNormal.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CambiarAVistaNormal);
        }
    }

    void CambiarACamaraZoom()
    {
        // Desactivar la cámara normal y activar la cámara de zoom
        if (camaraNormal != null)
        {
            camaraNormal.gameObject.SetActive(false);
            botonZoom.gameObject.SetActive(false);
           
        }

        if (camaraZoom != null)
        {
            camaraZoom.gameObject.SetActive(true);
            botonVistaNormal.gameObject.SetActive(true);
          
        }
    }

    void CambiarAVistaNormal()
    {
        // Desactivar la cámara de zoom y activar la cámara normal
        if (camaraZoom != null)
        {
            camaraZoom.gameObject.SetActive(false);
            botonVistaNormal.gameObject.SetActive(false);
        }

        if (camaraNormal != null)
        {
            camaraNormal.gameObject.SetActive(true);
            botonZoom.gameObject.SetActive(true);
           
        }
    }
}
