using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImprimiendoDatos : MonoBehaviour
{
    public float velocidadInicialMetrosPorSegundo = 10f; // Velocidad inicial del balón en metros por segundo
    public float anguloLanzamiento = 45f; // Ángulo de lanzamiento en grados
    public LineRenderer lineRenderer; // Referencia al LineRenderer
    public Material materialVerde; // Material verde
    public Material materialRojo; // Material rojo

    private Rigidbody rb;
    private List<Vector3> puntosTrayectoria = new List<Vector3>(); // Lista para almacenar las posiciones de la trayectoria
    private bool dibujarTrayectoria = true; // Control para habilitar o deshabilitar el dibujo de la trayectoria
    private float anguloTrayectoria; // Ángulo de la trayectoria

    public GameObject balon; // El objeto del balón en la escena
    public Transform puntoInicial; // El punto inicial del balón en la parábola
    public TextMeshPro alturaText; // El objeto TextMeshPro para mostrar la altura
    public TextMeshPro distanciaText; // El objeto TextMeshPro para mostrar la distancia
    public TextMeshPro velocidadText;
    public TextMeshPro anguloText;

    public bool respuesta = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar la gravedad inicialmente
        lineRenderer.positionCount = 2; // Configurar el número de puntos en la línea a 2 (inicio y fin)
        lineRenderer.SetPosition(0, transform.position); // Establecer el primer punto en la posición actual del objeto
        lineRenderer.SetPosition(1, transform.position); // Establecer el segundo punto igual al primero al inicio

        lineRenderer.material = materialVerde;

    }

    void Update()
    {
        // Detectar la entrada del usuario para lanzar el balón
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarBalon();
             if (respuesta == true)
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
            anguloText.text = "θ" + anguloTrayectoria.ToString("F2") + "°"; // "F2" para mostrar dos decimales
        }
    }

    void FixedUpdate()
    {
        // Actualizar la posición del segundo punto de la línea para seguir al balón
        lineRenderer.SetPosition(1, transform.position);

        // Agregar la posición actual del balón a la lista de puntos
        if (dibujarTrayectoria)
        {
            puntosTrayectoria.Add(transform.position);
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
    }

    private void OnCollisionEnter(Collision other)
    {
        // Verificar si el balón colisionó con otro objeto
        if (other.gameObject != null && other.gameObject != gameObject) // Asegurarse de que no sea el propio balón
        {
            // Detener el LineRenderer
            dibujarTrayectoria = false;
        }
    }
}