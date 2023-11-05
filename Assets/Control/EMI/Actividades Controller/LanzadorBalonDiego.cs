using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanzadorBalonDiego : MonoBehaviour
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

    public GameObject balon; // El objeto del balón en la escena
    public Transform balonD;
    public Transform puntoObjetivo;
    public GameObject barraAltura;
    public GameObject barraDistancia; // El objeto del balón en la escena
    public Transform puntoInicial; // El punto inicial del balón en la parábola
    public TextMeshPro alturaText; // El objeto TextMeshPro para mostrar la altura
    public TextMeshPro distanciaText; // El objeto TextMeshPro para mostrar la distancia
    public TextMeshPro velocidadText;
    public TextMeshPro anguloText;
    public float nuevaPosicionY; 
    public float nuevaPosicionx; 
    public float nuevaPosicionz; 

    void Start()
    {
        Vector3 posicionActual = balonD.position;
        nuevaPosicionY = CE.AlturaD;
        nuevaPosicionx = 13.728f - CE.DistanciaD;
        nuevaPosicionz = 3.74f;
        // Cambia la posición en el eje Y a la nueva posición deseada
        posicionActual.y =  nuevaPosicionY;
        posicionActual.x =  nuevaPosicionx;
        posicionActual.z =  nuevaPosicionz;

        // Asigna la nueva posición al objeto
        balonD.position = posicionActual;
        puntoInicial.position = posicionActual;

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
    }

    void Update()
    {
        Debug.Log("Juan Altura!!!!!!: " +nuevaPosicionY);
        Debug.Log("Juan Distancia!!!!!: " +nuevaPosicionx);

        // Detectar la entrada del usuario para lanzar el balón
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarBalon();
            
            if (CE.LanzamientoD == 1)
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
    float anguloRad = Mathf.Deg2Rad * CE.AnguloD;
    float velocidadX = CE.VelocidadInicialD * Mathf.Cos(anguloRad);
    float velocidadY = CE.VelocidadInicialD * Mathf.Sin(anguloRad);
    float velocidadZ = (puntoObjetivo.position.z - transform.position.z) / (CE.VelocidadInicialD * Mathf.Cos(anguloRad));

    // Aplicar la velocidad inicial al balón
    rb.velocity = new Vector3(velocidadX, velocidadY, -1.3f);

    // Reducir el tiempo escalar para simular la cámara lenta (ajusta según tus necesidades)
    Time.timeScale = 0.1f; // Cambia este valor para ajustar la velocidad de cámara lenta
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
