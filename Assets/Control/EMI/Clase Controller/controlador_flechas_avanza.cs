using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class controlador_flechas_avanza : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider mySlider; // Nueva variable para el Slider
    private double[] sectionStartTimes = { 0, 138, 298, 594 }; // Marcas de tiempo de las secciones
    private int currentSectionIndex = 0; // Índice de la sección actual

    public Transform contenedorBotones; // Objeto vacío que contendrá los botones
    public Button avanzarBoton;
    public Button retrocederBoton;

    public GameObject seccion1;
    public GameObject seccion1visto;
    public GameObject seccion2;
    public GameObject seccion2visto;
    public GameObject seccion3;
    public GameObject seccion3visto;
    public GameObject seccion4;
    public GameObject seccion4visto;

    // Las coordenadas X e Y de los botones para cada sección
    private Vector2[] botonesPosiciones = { new Vector2(-302f, 1.2f), new Vector2(-89f, 1.2f), new Vector2(110f, 1.2f), new Vector2(297f, 1.2f), new Vector2(-78.1f, 1.2f) };

    private void Start()
    {
        if (videoPlayer == null || avanzarBoton == null || retrocederBoton == null || contenedorBotones == null || mySlider == null)
        {
            Debug.LogError("Asegúrate de asignar todos los componentes en el Inspector.");
            return;
        }

        avanzarBoton.onClick.AddListener(AvanzarAInicioSeccion);
        retrocederBoton.onClick.AddListener(RetrocederAInicioSeccion);

        // Ajusta la posición inicial del contenedor de botones
        contenedorBotones.GetComponent<RectTransform>().anchoredPosition = botonesPosiciones[currentSectionIndex];

        // Asigna el valor inicial del Slider a 0
        mySlider.value = 0;
    }

    private void Update()
    {
        if (videoPlayer.length == 0)
        {
            return;
        }

        // Calcula el porcentaje del video reproducido
        float percentage = Mathf.Clamp((float)(videoPlayer.time / videoPlayer.length) * 100f, 0f, 100f);

        // Verifica si se debe avanzar a la siguiente sección
        if (currentSectionIndex + 1 < sectionStartTimes.Length && percentage >= sectionStartTimes[currentSectionIndex + 1])
        {
            AvanzarAInicioSeccion();
        }

        // Actualiza la posición del contenedor de botones
        contenedorBotones.GetComponent<RectTransform>().anchoredPosition = botonesPosiciones[currentSectionIndex];

        if (botonesPosiciones[currentSectionIndex].x == -302f)
        {
            seccion1.gameObject.SetActive(true);
            seccion2.gameObject.SetActive(true);
            seccion3.gameObject.SetActive(true);
            seccion4.gameObject.SetActive(true);
            seccion1visto.gameObject.SetActive(false);

        }
        else if (botonesPosiciones[currentSectionIndex].x == -89f)
        {
            seccion1.gameObject.SetActive(false);
            seccion2.gameObject.SetActive(true);
            seccion1visto.gameObject.SetActive(true);
            seccion2visto.gameObject.SetActive(false);

        }
        else if (botonesPosiciones[currentSectionIndex].x == 110f)
        {
            seccion2.gameObject.SetActive(false);
            seccion3.gameObject.SetActive(true);
            seccion4.gameObject.SetActive(true);
            seccion2visto.gameObject.SetActive(true);
            seccion1visto.gameObject.SetActive(true);
            seccion3visto.gameObject.SetActive(false);
            seccion4visto.gameObject.SetActive(false);


        }
        else if (botonesPosiciones[currentSectionIndex].x == 297f)
        {
            seccion3.gameObject.SetActive(false);
            seccion4.gameObject.SetActive(false);
            seccion3visto.gameObject.SetActive(true);
            seccion2visto.gameObject.SetActive(true);
            seccion1visto.gameObject.SetActive(true);
            seccion4visto.gameObject.SetActive(true);
        }
    }

    private void AvanzarAInicioSeccion()
    {
        // Establece el índice de la siguiente sección
        int nextSectionIndex = currentSectionIndex + 1;
        if (nextSectionIndex < sectionStartTimes.Length)
        {
            currentSectionIndex = nextSectionIndex;

            // Avanza a la marca de tiempo de inicio de la sección actual
            videoPlayer.time = sectionStartTimes[currentSectionIndex];

            // Inicia el video desde el inicio de la sección actual
            videoPlayer.Play();

            // Ajusta el valor del Slider según las condiciones
            if (currentSectionIndex == 1)
            {
                mySlider.value = 30;
            }
            else if (currentSectionIndex == 2)
            {
                mySlider.value = 70;
            }
            else if (currentSectionIndex == 3)
            {
                mySlider.value = 100;
            }
        }
    }

    private void RetrocederAInicioSeccion()
    {
        // Establece el índice de la sección anterior
        int previousSectionIndex = currentSectionIndex - 1;
        if (previousSectionIndex >= 0)
        {
            currentSectionIndex = previousSectionIndex;

            // Retrocede a la marca de tiempo de inicio de la sección actual
            videoPlayer.time = sectionStartTimes[currentSectionIndex];

            // Inicia el video desde el inicio de la sección actual
            videoPlayer.Play();

            // Ajusta el valor del Slider según las condiciones
            if (currentSectionIndex == 0)
            {
                mySlider.value = 0;
            }
            else if (currentSectionIndex == 1)
            {
                mySlider.value = 21;
            }
            else if (currentSectionIndex == 2)
            {
                mySlider.value = 60;
            }
        }
    }
}
