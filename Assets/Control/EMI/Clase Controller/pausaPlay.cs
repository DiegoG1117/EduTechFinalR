using UnityEngine;
using UnityEngine.UI;

public class pausaPlay : MonoBehaviour
{
    public Button boton;

    public RawImage imagen1;
    public RawImage imagen2;

    bool mostrandoImagen1 = true;

    void Start()
    {
        if (boton != null)
        {
            boton.onClick.AddListener(CambiarImagenBoton);
        }

        // Asegurar que solo una de las imágenes esté activa al inicio
        ActualizarImagenes();
    }

    void CambiarImagenBoton()
    {
        // Cambiar entre las imágenes cuando se hace clic en el botón
        mostrandoImagen1 = !mostrandoImagen1;

        // Actualizar el estado de las imágenes
        ActualizarImagenes();
    }

    void ActualizarImagenes()
    {
        if (imagen1 != null)
        {
            imagen1.gameObject.SetActive(mostrandoImagen1);
        }

        if (imagen2 != null)
        {
            imagen2.gameObject.SetActive(!mostrandoImagen1);
        }
    }
}
