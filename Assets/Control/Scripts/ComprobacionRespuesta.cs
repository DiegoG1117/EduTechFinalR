using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobacionRespuesta : MonoBehaviour
{
    public Transform balon;
    public Transform balonJ;
    public Transform balonR;
    public ControladorDiego controlDiego;
    public ControladorJuan controlJuan;
    public ControladorRoberto controlRoberto;
    public EnviandoDatos DatosRecibidos;
    public float nuevaPosicionY; 
    public float nuevaPosicionx; 
    public float nuevaPosicionY2; 
    public float nuevaPosicionx2; 
    private  Rigidbody rb, rb2, rb3;
    public float Velocidad0; // Velocidad inicial del balón en metros por segundo
    public float angulo; // Ángulo de lanzamiento en grados

    // Start is called before the first frame update
    void Start()
    {

        rb = balon.GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar la gravedad inicialmente 

        Vector3 posicionActual = balon.position;
        nuevaPosicionY = 0.45f +controlDiego.metrosEquivalentes;
        nuevaPosicionx = -6.70235f - controlDiego.distancia;
        // Cambia la posición en el eje Y a la nueva posición deseada
        posicionActual.y =  nuevaPosicionY;
        posicionActual.x =  nuevaPosicionx;

        // Asigna la nueva posición al objeto
        balon.position = posicionActual;

        rb2 = balonJ.GetComponent<Rigidbody>();
        rb2.useGravity = false; // Desactivar la gravedad inicialmente 

        Vector3 posicionActualJ = balonJ.position;
        nuevaPosicionY = 0.45f +controlJuan.metrosEquivalentes;
        nuevaPosicionx = -6.70235f - controlJuan.distanciaJ;
        // Cambia la posición en el eje Y a la nueva posición deseada
        posicionActualJ.y =  nuevaPosicionY;
        posicionActualJ.x =  nuevaPosicionx;

        // Asigna la nueva posición al objeto
        balonJ.position = posicionActualJ;

        rb3 = balonR.GetComponent<Rigidbody>();
        rb3.useGravity = false; // Desactivar la gravedad inicialmente 
        
        Vector3 posicionActualR = balonR.position;
        nuevaPosicionY2 = 0.45f + controlRoberto.metrosEquivalentes;
        nuevaPosicionx2 = -6.70235f - controlRoberto.distancia;
        // Cambia la posición en el eje Y a la nueva posición deseada
        posicionActualR.y =  nuevaPosicionY2;
        posicionActualR.x =  nuevaPosicionx2;

        // Asigna la nueva posición al objeto
        balonR.position = posicionActualR;
                
     
    }

    // Update is called once per frame
    void Update()
    {   
        if(DatosRecibidos.TerminandoejercicioDiego == true){
        
        rb.useGravity = true;
        Velocidad0 = DatosRecibidos.dato1D;
        angulo = DatosRecibidos.dato2D;
        float anguloRad = Mathf.Deg2Rad * angulo;
        float velocidadX = Velocidad0 * Mathf.Cos(anguloRad);
        float velocidadY = Velocidad0 * Mathf.Sin(anguloRad);
        rb.velocity = new Vector3(velocidadX, velocidadY, 0);
        DatosRecibidos.TerminandoejercicioDiego = false;
        }
        if(DatosRecibidos.TerminandoejercicioJuan == true){
        rb2.useGravity = true;
        Velocidad0 = DatosRecibidos.dato1J;
        angulo = DatosRecibidos.dato2J;
        float anguloRad = Mathf.Deg2Rad * angulo;
        float velocidadX = Velocidad0 * Mathf.Cos(anguloRad);
        float velocidadY = Velocidad0 * Mathf.Sin(anguloRad);
        rb2.velocity = new Vector3(velocidadX, velocidadY, 0);
        DatosRecibidos.TerminandoejercicioJuan = false;
        }
        if(DatosRecibidos.TerminandoejercicioRoberto == true){
        rb3.useGravity = true;
        Velocidad0 = DatosRecibidos.dato1R;
        angulo = DatosRecibidos.dato2R;
        float anguloRad = Mathf.Deg2Rad * angulo;
        float velocidadX = Velocidad0 * Mathf.Cos(anguloRad);
        float velocidadY = Velocidad0 * Mathf.Sin(anguloRad);
        rb3.velocity = new Vector3(velocidadX, velocidadY, 0);
        DatosRecibidos.TerminandoejercicioRoberto = false;
        }



    }
}
