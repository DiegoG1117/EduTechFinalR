using UnityEngine;
using TMPro;

public class ControladorDiego : MonoBehaviour
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
    public float escalaMinima = 0.009528005f;
    public float escalaMaxima = 0.0100367f;

    // Sirve para pasar a metros 
    public float metrosEquivalentes;
    public float distancia;
    // Distancia de posicion base de roberto frente al arco 
    public float posicionMinimaX = -11f;
    public float posicionMaximaX = -10.432f;
    public float posicionMinimaZ = -7.26f;
    public float posicionMaximaZ = -8.087f;

    // Objetos UI que se aplican en la vista del canvas de Roberto
    public TextMeshPro AlturaD; 
    public TextMeshPro PracticaD; 
    public TextMeshPro  DistanciaD; 
    
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

        // Genera una posición aleatoria en el rango deseado en el eje Z
        float posicionAleatoriaZ = Random.Range(posicionMinimaZ, posicionMaximaZ);

        // Calcula los metros equivalentes
        metrosEquivalentes = Remap(escalaAleatoria, escalaMinima, escalaMaxima, 1.70f, 1.80f);
        personaje.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria);

        // Mantén las coordenadas en los ejes Y y Z del personaje sin cambios
        Vector3 nuevaPosicion = personaje.position;
        nuevaPosicion.x = posicionAleatoriaX;
        nuevaPosicion.z = posicionAleatoriaZ;
        personaje.position = nuevaPosicion;

        // Calcula la distancia entre el personaje y el objeto a comparar
        distancia = Vector3.Distance(personaje.position, objetoAComparar.position);

        // Cambiar el texto en tiempo de ejecución
        
        AlturaD.text = "Altura Diego : " + metrosEquivalentes.ToString("F2");
        PracticaD.text = "Tienes que ingresar la velocidad y un angulo superior a 75 grados para poder realizar el lanzamiento exitoso. Utiliza los datos mostrados en el escenario para calcular los valores, puedes utilizar las formulas para darte apoyo a la hora de resolver el ejercicio";
        DistanciaD.text = distancia.ToString("F2") + "M" ;

        // Imprime la posición aleatoria en X y Z
        Debug.Log("Posición aleatoria en X de Diego  : " + posicionAleatoriaX.ToString("F4"));
        Debug.Log("Posición aleatoria en Z de Diego  : " + posicionAleatoriaZ.ToString("F4"));

        // Imprime la distancia en la consola
        Debug.Log("Distancia entre el personaje y el objeto de Diego  : " + distancia.ToString("F2") + " metros");

        // Muestra los metros equivalentes en la consola
        Debug.Log("La escala aleatoria de Diego : " + escalaAleatoria + " equivale a " + metrosEquivalentes.ToString("F2")+ " metros.");

    }
    
    // Función para mapear un valor de un rango a otro
    float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }
}
