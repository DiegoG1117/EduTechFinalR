using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEstadio : MonoBehaviour
{
    public float VelocidadInicialD;
    public float AnguloD;
    public float AlturaD;
    public float DistanciaD;
    public int LanzamientoD = 0;
    public float VelocidadInicialJ;
    public float AnguloJ;
    public float AlturaJ;
    public float DistanciaJ;
    public int LanzamientoJ = 0;
    public float VelocidadInicialR;
    public float AnguloR;
    public float AlturaR;
    public float DistanciaR;
    public int LanzamientoR = 0;

    // Start is called before the first frame update
    void Awake()
    {
        VelocidadInicialD = PlayerPrefs.GetFloat("V0Diego");
        AnguloD = PlayerPrefs.GetFloat("ADiego");
        AlturaD = PlayerPrefs.GetFloat("AlturaDiego");
        DistanciaD = PlayerPrefs.GetFloat("DistanciaDiego");
        LanzamientoD = PlayerPrefs.GetInt("TiroDiego");

        VelocidadInicialJ = PlayerPrefs.GetFloat("V0Juan");
        AnguloJ = PlayerPrefs.GetFloat("AJuan");
        AlturaJ = PlayerPrefs.GetFloat("AlturaJuan");
        DistanciaJ = PlayerPrefs.GetFloat("DistanciaJuan");
        LanzamientoJ = PlayerPrefs.GetInt("TiroJuan");

        VelocidadInicialR = PlayerPrefs.GetFloat("V0Roberto");
        AnguloR = PlayerPrefs.GetFloat("ARoberto");
        AlturaR = PlayerPrefs.GetFloat("AlturaRoberto");
        DistanciaR = PlayerPrefs.GetFloat("DistanciaRoberto");
        LanzamientoR = PlayerPrefs.GetInt("TiroRoberto");

        
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("Diego Velocidad: " + VelocidadInicialD);
         Debug.Log("Diego Angulo: " +AnguloD);
         Debug.Log("Diego Altura: " +AlturaD);
         Debug.Log("Diego Distancia: " +DistanciaD);
         Debug.Log("Diego Lanzamiento: " +LanzamientoD);

         Debug.Log("Juan Velocidad: " + VelocidadInicialJ);
         Debug.Log("Juan Angulo: " +AnguloJ);
         Debug.Log("Juan Altura: " +AlturaJ);
         Debug.Log("Juan Distancia: " +DistanciaJ);
         Debug.Log("Juan Lanzamiento: " +LanzamientoJ);

         Debug.Log("Roberto Velocidad: " + VelocidadInicialR);
         Debug.Log("Roberto Angulo: " +AnguloR);
         Debug.Log("Roberto Altura: " +AlturaR);
         Debug.Log("Roberto Distancia: " +DistanciaR);
         Debug.Log("Roberto Lanzamiento: " +LanzamientoR);
         
    }
}
