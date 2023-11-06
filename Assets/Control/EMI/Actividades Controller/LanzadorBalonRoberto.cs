using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanzadorBalonRoberto : MonoBehaviour
{
    public ControladorEstadio CE;
    public LineRenderer lineRenderer; // Referencia al LineRenderer
    public LineRenderer lineRenderer2; // Referencia al LineRenderer
    public Material materialVerde; // Material verde
    public Material materialRojo; // Material rojo

    private Rigidbody rb;
    private List<Vector3> puntosTrayectoria = new List<Vector3>(); // Lista para almacenar las posiciones de la trayectoria
    private bool dibujarTrayectoria = true; // Control para habilitar o deshabilitar el dibujo de la trayectoria
    private float anguloTrayectoria; // Ángulo de la trayectoria
    public bool respuesta = true; // Booleano que determina el color del LineRenderer

    private float tiempoEscalaOriginal; // Almacena el tiempo escala original

    [SerializeField] TMP_Text textoResultado;
    public Button botonRepetir;
    [SerializeField] TMP_Text textoVelocidad1;
    [SerializeField] TMP_Text textoAngulo1;

    public GameObject balon; // El objeto del balón en la escena
    public Transform balonR;
    public GameObject barraAltura;
    public GameObject barraDistancia; // El objeto del balón en la escena
    public Transform puntoInicial; // El punto inicial del balón en la parábola
    public Transform RobertoPosicion; // El punto inicial del balón en la parábola
    public TextMeshPro alturaText; // El objeto TextMeshPro para mostrar la altura
    public TextMeshPro distanciaText; // El objeto TextMeshPro para mostrar la distancia
    public TextMeshPro velocidadText;
    public TextMeshPro anguloText;
    public float nuevaPosicionY; 
    public float nuevaPosicionx;

    /// <summary>
    /// ////////////////////////////////////////////////////
    /// </summary>


    void Start()
    {
        Vector3 posicionActual = balonR.position;
        nuevaPosicionY = CE.AlturaR;
        nuevaPosicionx = 13.728f - CE.DistanciaR;
        // Cambia la posición en el eje Y a la nueva posición deseada
        posicionActual.y =  nuevaPosicionY;
        posicionActual.x =  nuevaPosicionx;

        // Asigna la nueva posición al objeto
        balonR.position = posicionActual;
        puntoInicial.position = posicionActual;
        RobertoPosicion.position = posicionActual;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar la gravedad inicialmente
        lineRenderer.positionCount = 2; // Configurar el número de puntos en la línea a 2 (inicio y fin)
        lineRenderer.SetPosition(0, transform.position); // Establecer el primer punto en la posición actual del objeto
        lineRenderer.SetPosition(1, transform.position); // Establecer el segundo punto igual al primero al inicio
        lineRenderer2.positionCount = 2; // Configurar el número de puntos en la línea a 2 (inicio y fin)
        lineRenderer2.SetPosition(0, transform.position); // Establecer el primer punto en la posición actual del objeto
        lineRenderer2.SetPosition(1, transform.position); // Establecer el segundo punto igual al primero al inicio

        lineRenderer.material = materialVerde;

        // Almacenar el tiempo escala original
        tiempoEscalaOriginal = Time.timeScale;
        barraAltura.SetActive(true);
        barraDistancia.SetActive(true);
        alturaText.enabled = true; 
        velocidadText.enabled = true; 
        anguloText.enabled = true; 
        distanciaText.enabled = true;

        PlayerPrefs.HasKey("Valor5");
        PlayerPrefs.HasKey("Valor6");

        float valor5 = PlayerPrefs.GetFloat("Valor5");
        float valor6 = PlayerPrefs.GetFloat("Valor6");

        if (CE.LanzamientoR == 1)
        {
            //lineRenderer.material = materialVerde;
            textoResultado.text = "Exitoso";
            textoResultado.color = Color.green;
            botonRepetir.gameObject.SetActive(false); // Desactiva el botón
        }
        else
        {
            //lineRenderer.material = materialRojo;
            textoResultado.text = "Fallido";
            textoResultado.color = Color.red;
            botonRepetir.gameObject.SetActive(true); // Activa el botón
        }

        MostrarValores("Velocidad : ", valor5, "Ángulo : ", valor6, textoVelocidad1, textoAngulo1);

    }

    void Update()
    {


        // Detectar la entrada del usuario para lanzar el balón
        if (Input.GetKeyDown(KeyCode.Space))
        {

           

            LanzarBalon();
            
            if (CE.LanzamientoR == 1)
            {
                lineRenderer.material = materialVerde;
           
            }
            else
            {
                lineRenderer.material = materialRojo;
               
            }

         
        }

        if (balon != null && puntoInicial != null && alturaText != null && distanciaText != null)
        {
            // Obtener la altura del balón
            float altura = balon.transform.position.y;

            // Calcular la distancia entre el punto inicial y la posición actual del balón
            float distancia = Vector3.Distance(puntoInicial.position, balon.transform.position);

            // Actualizar el TextMeshPro de altura con la altura
            alturaText.text = "Altura: " + altura.ToString("F2") + "M"; // "F2" para mostrar dos decimales

            // Actualizar el TextMeshPro de distancia con la distancia
            distanciaText.text = "Distancia: " + distancia.ToString("F2") + "M"; // "F2" para mostrar dos decimales

            velocidadText.text = "V: " + rb.velocity.magnitude.ToString("F2") + "m/s"; // "F2" para mostrar dos decimales

            // Actualizar el TextMeshPro de distancia con la distancia
            anguloText.text = "θ: " + anguloTrayectoria.ToString("F2") + "°"; // "F2" para mostrar dos decimales
        }
    }

    void MostrarResultado(TMP_Text texto, string mensaje, Color color)
    {
        texto.text = mensaje;
        texto.color = color;
    }

    void MostrarValores(string prefixVelocidad, float velocidad, string prefixAngulo, float angulo, TMP_Text textoVelocidad, TMP_Text textoAngulo)
    {
        textoVelocidad.text = prefixVelocidad + velocidad.ToString("F1") + " m/s"; // Mostrar dos decimales
        textoAngulo.text = prefixAngulo + angulo.ToString("F0") + "°"; // Mostrar dos decimales
    }

    void FixedUpdate()
    {
        // Actualizar la posición del segundo punto de la línea para seguir al balón
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer2.SetPosition(1, transform.position);

        // Agregar la posición actual del balón a la lista de puntos
        if (dibujarTrayectoria)
        {
            puntosTrayectoria.Add(transform.position);
            // Actualizar el LineRenderer con los puntos de la trayectoria
        }

        // Actualizar el LineRenderer con los puntos de la trayectoria
        lineRenderer.positionCount = puntosTrayectoria.Count;
        lineRenderer.SetPositions(puntosTrayectoria.ToArray());

        // Calcular el ángulo de la trayectoria
        Vector3 velocidad = rb.velocity;
        anguloTrayectoria = Mathf.Atan2(velocidad.y, velocidad.x) * Mathf.Rad2Deg;
    }

    void LanzarBalon()
    {
        // Activar la gravedad
        rb.useGravity = true;

        // Calcular las componentes del vector de velocidad inicial en Unity
        float anguloRad = Mathf.Deg2Rad * CE.AnguloR;
        float velocidadX = CE.VelocidadInicialR * Mathf.Cos(anguloRad);
        float velocidadY = CE.VelocidadInicialR * Mathf.Sin(anguloRad);

        // Aplicar la velocidad inicial al balón
        rb.velocity = new Vector3(velocidadX, velocidadY, 0);
        
        // Reducir el tiempo escalar para simular la cámara lenta (ajusta según tus necesidades)
        Time.timeScale = 0.05f; // Cambia este valor para ajustar la velocidad de cámara lenta


    }



    private void OnCollisionEnter(Collision other)
    {
        // Verificar si el balón colisionó con otro objeto
        if (other.gameObject != null && other.gameObject != gameObject) // Asegurarse de que no sea el propio balón
        {
            // Detener el LineRenderer
            dibujarTrayectoria = false;
            barraAltura.SetActive(false);
            barraDistancia.SetActive(false);
            alturaText.enabled = false; 
            velocidadText.enabled = false; 
            anguloText.enabled = false; 
            distanciaText.enabled = false; 
            // Restaurar el tiempo escala original
            Time.timeScale = tiempoEscalaOriginal;
        }
    }

    
}
