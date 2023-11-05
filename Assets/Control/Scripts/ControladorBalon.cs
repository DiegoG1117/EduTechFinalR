using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ControladorBalon : MonoBehaviour
{
    //DATOS PARA REALIZAR EL MOVIMIENTO PARABOLICO
    public float velocidadInicialMetrosPorSegundo = 10f; // Velocidad inicial del balón en metros por segundo
    public float anguloLanzamiento = 45f; // Ángulo de lanzamiento en grados


    //LINEA DE TRAYECTORIA
    public LineRenderer lineRenderer; // Referencia al LineRenderer
    public LineRenderer lineRenderer2; // Referencia al LineRenderer
    public Material materialVerde; // Material verde
    public Material materialRojo; // Material rojo
    private Rigidbody rb; //Componente rigidbody para cancelar las fisicas del balon
    private List<Vector3> puntosTrayectoria = new List<Vector3>(); // Lista para almacenar las posiciones de la trayectoria
    private bool dibujarTrayectoria = true; // Control para habilitar o deshabilitar el dibujo de la trayectoria
    private float anguloTrayectoria; // Ángulo de la trayectoria
    public bool respuesta = true; // Booleano que determina el color del LineRenderer
    private float tiempoEscalaOriginal; // Almacena el tiempo escala original real para luego hacerlo en camara lenta


    //TEXTOS QUE DICEN LAS MEDIDAS 
    public GameObject balon; // El objeto del balón en la escena
    public GameObject barraAltura; //Esta es la barra que simula un linerender que muestra la altura del balon 
    public GameObject barraDistancia; //Esta es la barra que simula un linerender que muestra la altura del balon 
    public Transform puntoInicial; // El punto inicial del balón en la parábola
    public TextMeshPro alturaText; // El objeto TextMeshPro para mostrar la altura
    public TextMeshPro distanciaText; // El objeto TextMeshPro para mostrar la distancia
    public TextMeshPro velocidadText; // El objeto TextMeshPro para mostrar la velocidad
    public TextMeshPro anguloText; // El objeto TextMeshPro para mostrar el angulo

    void Start()
    {
        // INICIALIZANDO LAS POSICIONES DEL LINERENDER 1 Y 2 
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar la gravedad inicialmente
        lineRenderer.positionCount = 2; // Configurar el número de puntos en la línea a 2 (inicio y fin)
        lineRenderer.SetPosition(0, transform.position); // Establecer el primer punto en la posición actual del objeto
        lineRenderer.SetPosition(1, transform.position); // Establecer el segundo punto igual al primero al inicio
        lineRenderer2.positionCount = 2; // Configurar el número de puntos en la línea a 2 (inicio y fin)
        lineRenderer2.SetPosition(0, transform.position); // Establecer el primer punto en la posición actual del objeto
        lineRenderer2.SetPosition(1, transform.position); // Establecer el segundo punto igual al primero al inicio

        //SE INICIALIZA EL LINERENDER DE LA TRAYECTORIA DE COLOR VERDE 
        lineRenderer.material = materialVerde;

        //ALMACENANDO LA ESCALA DEL TIEMPO ORIGNAL PARA LUEGO PODER HACERLE CAMBIOS
        tiempoEscalaOriginal = Time.timeScale;

        //INICIALIZANDO LOS OBJETOS DE TEXTO CON LAS MEDIDAS COMO VISIBLES
        barraAltura.SetActive(true);
        barraDistancia.SetActive(true);
        alturaText.enabled = true; 
        velocidadText.enabled = true; 
        anguloText.enabled = true; 
        distanciaText.enabled = true; 

        
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.F))
        {
            respuesta = false;
        }
        
        // Cambiar el valor de respuesta cuando se presiona la tecla T
        if (Input.GetKeyDown(KeyCode.T))
        {
            respuesta = true;
        }

        // Detectar la entrada del usuario para lanzar el balón
   // Detectar la entrada del usuario para lanzar el balón
    if (Input.GetKeyDown(KeyCode.Space))
    {
        LanzarBalon();

        // Cambiar el valor de respuesta cuando se presiona la tecla F
    
        // Actualizar el material del LineRenderer según el valor de respuesta
        if (respuesta == true)
        {
            lineRenderer.material = materialVerde;
        }
        else
        {
            lineRenderer.material = materialRojo;
        }
    }


        //REVISANDO QUE SE CUMPLA CON LOS PARAMETROS NECESARIOS PARA MOSTRAR LOS DATOS DE LA TRAYECTORIA 
        if (balon != null && puntoInicial != null && alturaText != null && distanciaText != null && velocidadText != null && anguloText != null)
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
        float anguloRad = Mathf.Deg2Rad * anguloLanzamiento;
        float velocidadX = velocidadInicialMetrosPorSegundo * Mathf.Cos(anguloRad);
        float velocidadY = velocidadInicialMetrosPorSegundo * Mathf.Sin(anguloRad);

        // Aplicar la velocidad inicial al balón
        rb.velocity = new Vector3(velocidadX, velocidadY, 0);
        
        // Reducir el tiempo escalar para simular la cámara lenta (ajusta según tus necesidades)
        Time.timeScale = 0.4f; // Cambia este valor para ajustar la velocidad de cámara lenta
    }

    private void OnCollisionEnter(Collision other)
    {
        // Verificar si el balón colisionó con otro objeto
        if (other.gameObject != null && other.gameObject != gameObject) // Asegurarse de que no sea el propio balón
        {
            //DETENER LOS TEXTOS Y EL LINERENDER2 

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

    
    public void Reiniciar()
    {
        // Carga la escena "Testeo2" para reiniciarla
        SceneManager.LoadScene("Testeo2");
    }
}
