using UnityEngine;
using TMPro;

public class ControladorJuan : MonoBehaviour
{

    public Transform InicioAltura; // El objeto de inicio (objeto vacío) al que se conectará el LineRenderer.
    public Transform FinAltura; // El objeto final (objeto vacío) al que se conectará el LineRenderer.
    public Transform InicioDistancia; // El objeto de inicio (objeto vacío) al que se conectará el LineRenderer.
    public Transform FinDistancia; // El objeto final (objeto vacío) al que se conectará el LineRenderer.
    public LineRenderer lineRendererAltura; // Referencia al LineRenderer.
    public LineRenderer lineRendererDistancia; // Referencia al LineRenderer.

    // Personaje al que se le va a aplicar los cambios
    public Transform personaje; 
    // Objeto con el que se va a comparar la distancia al arco
    public Transform objetoAComparar; 

    // Estas son las medidas de escala para la altura 
    public float escalaMinima = 0.004858956f;
    public float escalaMaxima = 0.005076001f;

    // Sirve para pasar a metros 
    public float metrosEquivalentes;

    public float distanciaJ;

    // Distancia de posicion base de roberto frente al arco 
    public float posicionMinimaX = -8.998f;
    public float posicionMaximaX = -8.95f;

    // Objetos UI que se aplican en la vista del canvas de Roberto
    public TextMeshPro AlturaJ; 
    public TextMeshPro PracticaJ; 
    public TextMeshPro  DistanciaJ; 
    
    void Awake()
    {

        lineRendererAltura.positionCount = 2; // Dos puntos: inicio y final.
        lineRendererAltura.SetPosition(0, InicioAltura.position); // Establece el punto de inicio en la posición del objeto de inicio.
        lineRendererAltura.SetPosition(1, FinAltura.position); // Establece el punto final en la posición del objeto final.

        lineRendererDistancia.positionCount = 2; // Dos puntos: inicio y final.
        lineRendererDistancia.SetPosition(0, InicioDistancia.position); // Establece el punto de inicio en la posición del objeto de inicio.
        lineRendererDistancia.SetPosition(1, FinDistancia.position); // Establece el punto final en la posición del objeto final.

        // Genera una escala aleatoria en el rango deseado para altura
        float escalaAleatoria = Random.Range(escalaMinima, escalaMaxima);

        // Genera una posición aleatoria en el rango deseado en el eje X
        float posicionAleatoriaX = Random.Range(posicionMinimaX, posicionMaximaX);

        // Calcula los metros equivalentes
        metrosEquivalentes = Remap(escalaAleatoria, escalaMinima, escalaMaxima, 1.80f, 1.90f);
        personaje.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria);

        // Mantén las coordenadas en los ejes x
        Vector3 nuevaPosicion = personaje.position;
        nuevaPosicion.x = posicionAleatoriaX;
        personaje.position = nuevaPosicion;

        // Calcula la distancia entre el personaje y el objeto a comparar
        distanciaJ = Vector3.Distance(personaje.position, objetoAComparar.position);

        // Cambiar el texto en tiempo de ejecución
        
        AlturaJ.text = "Altura Juan: " + metrosEquivalentes.ToString("F2");
        PracticaJ.text = "Tienes que ingresar la velocidad y el ángulo del tiro para poder realizar el lanzamiento de falta exitoso. Utiliza los datos mostrados en el escenario para calcular los valores, puedes utilizar las fórmulas para darte apoyo a la hora de resolver el ejercicio";
        DistanciaJ.text = distanciaJ.ToString("F2") + "M" ;

        // Imprime la posición aleatoria en X y Z
     //   Debug.Log("Posición aleatoria en X de Juan : " + posicionAleatoriaX.ToString("F4"));

        // Imprime la distancia en la consola
       // Debug.Log("Distancia entre el personaje y el objeto de Juan : " + distancia.ToString("F2") + " metros");

        // Muestra los metros equivalentes en la consola
    //    Debug.Log("La escala aleatoria de Juan: " + escalaAleatoria + " equivale a " + metrosEquivalentes.ToString("F2")+ " metros.");

    }

    // Función para mapear un valor de un rango a otro
    float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }
}
