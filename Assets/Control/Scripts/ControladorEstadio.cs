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
    public GameObject VistaJuan;
    public GameObject PosicionJuan;
    public GameObject PIJuan;
    public GameObject BalonJuan;
    public GameObject VistaDiego;
    public GameObject PosicionDiego;
    public GameObject PIDiego;
    public GameObject BalonDiego;
    public GameObject VistaRoberto;
    public GameObject PosicionRoberto;
    public GameObject PIRoberto;
    public GameObject BalonRoberto;
    

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

    void Start()
    {
        VistaJuan.SetActive(true);
        PosicionJuan.SetActive(true);
        PIJuan.SetActive(true);
        BalonJuan.SetActive(true);

        VistaDiego.SetActive(false);
        PosicionDiego.SetActive(false);
        PIDiego.SetActive(false);
        BalonDiego.SetActive(false);

        VistaRoberto.SetActive(false);
        PosicionRoberto.SetActive(false);
        PIRoberto.SetActive(false);
        BalonRoberto.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

         
    }
    public void RetroalimentacionDiego(){
        VistaJuan.SetActive(false);
        PosicionJuan.SetActive(false);
        PIJuan.SetActive(false);
        BalonJuan.SetActive(false);

        VistaDiego.SetActive(true);
        PosicionDiego.SetActive(true);
        PIDiego.SetActive(true);
        BalonDiego.SetActive(true);
    }
    public void RetroalimentacionRoberto(){
        VistaJuan.SetActive(false);
        PosicionJuan.SetActive(false);
        PIJuan.SetActive(false);
        BalonJuan.SetActive(false);

        VistaDiego.SetActive(false);
        PosicionDiego.SetActive(false);
        PIDiego.SetActive(false);
        BalonDiego.SetActive(false);

        VistaRoberto.SetActive(true);
        PosicionRoberto.SetActive(true);
        PIRoberto.SetActive(true);
        BalonRoberto.SetActive(true);
    }
}
