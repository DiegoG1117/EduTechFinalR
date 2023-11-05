using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGuardados : MonoBehaviour
{
    public ControladorDiego controlDiego;
    public ControladorJuan controlJuan;
    public ControladorRoberto controlRoberto;
    public EnviandoDatos DatosRecibidos;

    public float V0Diego;
    public float ADiego;
    public float AlturaDiego;
    public float DistanciaDiego;
    public int TiroDiego = 0;
    public float V0Juan;
    public float AJuan;
    public float AlturaJuan;
    public float DistanciaJuan;
    public int TiroJuan = 0;
    public float V0Roberto;
    public float ARoberto;
    public float AlturaRoberto;
    public float DistanciaRoberto;
    public int TiroRoberto = 0;
    
    // Update is called once per frame
    void Update()
    {
        if(TiroDiego == 1 || TiroDiego == 0 )
        {
            V0Diego = DatosRecibidos.dato1D;
            ADiego = DatosRecibidos.dato2D;
            AlturaDiego = controlDiego.metrosEquivalentes;
            DistanciaDiego = controlDiego.distancia;

            PlayerPrefs.SetInt("TiroDiego", TiroDiego);
            PlayerPrefs.SetFloat("V0Diego", V0Diego);
            PlayerPrefs.SetFloat("ADiego", ADiego);
            PlayerPrefs.SetFloat("AlturaDiego", AlturaDiego);
            PlayerPrefs.SetFloat("DistanciaDiego", DistanciaDiego);

        }
        if(TiroJuan == 1 || TiroJuan == 0 )
        {
            V0Juan = DatosRecibidos.dato1J;
            AJuan = DatosRecibidos.dato2J;
            AlturaJuan = controlJuan.metrosEquivalentes;
            DistanciaJuan = controlJuan.distanciaJ;

            PlayerPrefs.SetInt("TiroJuan", TiroJuan);
            PlayerPrefs.SetFloat("V0Juan", V0Juan);
            PlayerPrefs.SetFloat("AJuan", AJuan);
            PlayerPrefs.SetFloat("AlturaJuan", AlturaJuan);
            PlayerPrefs.SetFloat("DistanciaJuan", DistanciaJuan);

        }
        if(TiroRoberto == 1 || TiroRoberto == 0 )
        {
            V0Roberto = DatosRecibidos.dato1R;
            ARoberto = DatosRecibidos.dato2R;
            AlturaRoberto = controlRoberto.metrosEquivalentes;
            DistanciaRoberto = controlRoberto.distancia;

            PlayerPrefs.SetInt("TiroRoberto", TiroRoberto);
            PlayerPrefs.SetFloat("V0Roberto", V0Roberto);
            PlayerPrefs.SetFloat("ARoberto", ARoberto);
            PlayerPrefs.SetFloat("AlturaRoberto", AlturaRoberto);
            PlayerPrefs.SetFloat("DistanciaRoberto", DistanciaRoberto);

        }
        
    }
}
