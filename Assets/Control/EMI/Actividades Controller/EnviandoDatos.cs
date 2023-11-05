using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnviandoDatos : MonoBehaviour
{
    public TMP_InputField DVelocidad; // Asigna el primer InputField desde el Inspector
    public TMP_InputField DAngulo; // Asigna el segundo InputField desde el Inspector
    public TMP_InputField JVelocidad; // Asigna el primer InputField desde el Inspector
    public TMP_InputField JAngulo; // Asigna el segundo InputField desde el Inspector
    public TMP_InputField RVelocidad; // Asigna el primer InputField desde el Inspector
    public TMP_InputField RAngulo; // Asigna el segundo InputField desde el Inspector


    public float dato1D = 0f; // Variable para almacenar el primer dato como número
    public float dato2D = 0f; // Variable para almacenar el segundo dato como número

    public float dato1J = 0f; // Variable para almacenar el primer dato como número
    public float dato2J = 0f; // Variable para almacenar el segundo dato como número

    public float dato1R = 0f; // Variable para almacenar el primer dato como número
    public float dato2R = 0f; // Variable para almacenar el segundo dato como número

    public bool ejercicioJuan = false;
    public bool ejercicioDiego = false;
    public bool ejercicioRoberto = false;

    public bool TerminandoejercicioJuan = false;
    public bool TerminandoejercicioDiego = false;
    public bool TerminandoejercicioRoberto = false;
    public ControladorMenu ControladorMenuD;


public void DatosDiego()
    {
        // Obtén los valores de los InputFields y guárdalos como números
        dato1D = float.Parse(DVelocidad.text);
        dato2D = float.Parse(DAngulo.text);

        // Puedes mostrar los datos almacenados en un TextMeshPro

          Debug.Log("Dato 1: " + dato1D.ToString("F2") + "\nDato 2: " + dato2D.ToString("F2"));
          ejercicioDiego = true;
          TerminandoejercicioDiego = true;

         ControladorMenuD.Menu();

    }


public void DatosJuan()
    {
        // Obtén los valores de los InputFields y guárdalos como números
        dato1J = float.Parse(JVelocidad.text);
        dato2J = float.Parse(JAngulo.text);

        // Puedes mostrar los datos almacenados en un TextMeshPro

          Debug.Log("Dato 1: " + dato1J.ToString("F2") + "\nDato 2: " + dato2J.ToString("F2"));

          ejercicioJuan = true;
          TerminandoejercicioJuan = true;

         ControladorMenuD.Menu();

    }

 public void DatosRoberto()
    {
         dato1R = float.Parse(RVelocidad.text);
         dato2R = float.Parse(RAngulo.text);

            // Los valores se analizaron correctamente como flotantes, puedes continuar
            Debug.Log("Dato 1: " + dato1R.ToString("F2") + "\nDato 2: " + dato2R.ToString("F2"));
            ejercicioRoberto = true;
            TerminandoejercicioRoberto = true;
            ControladorMenuD.Menu();
            }
            
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
