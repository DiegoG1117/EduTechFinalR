using UnityEngine;

public class DistanciaJugador : MonoBehaviour
{
    public Transform personaje; // Arrastra el Transform del personaje al Inspector
    public Transform objetoAComparar; // Arrastra el Transform del objeto a comparar al Inspector

    void Update()
    {
        // Calcula la distancia entre el personaje y el objeto a comparar
        float distancia = Vector3.Distance(personaje.position, objetoAComparar.position);

        // Imprime la distancia en la consola
        Debug.Log("Distancia entre el personaje y el objeto: " + distancia.ToString("F2") + " METROS.");
    }
}
