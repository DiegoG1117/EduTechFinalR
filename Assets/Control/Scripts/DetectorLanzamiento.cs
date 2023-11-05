using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorLanzamiento : MonoBehaviour
{
    public EnviandoDatos DatosRecibidos;
    public GameObject balonDiego;
    public GameObject balonJuan;
    public GameObject balonRoberto;

    public DatosGuardados DG;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BalonComprobacionDiego") && DatosRecibidos.dato2D >= 75f)
        {
            // El balón colisionó con este objeto
            // Aquí puedes agregar el código para manejar la colisión
             Debug.Log("Tiro Exitoso de Diego");
             balonDiego.tag = "Untagged";
             DG.TiroDiego = 1;

        }
        if (other.CompareTag("BalonComprobacionJuan"))
        {
            // El balón colisionó con este objeto
            // Aquí puedes agregar el código para manejar la colisión
             Debug.Log("Tiro Exitoso de Juan");
             balonJuan.tag = "Untagged";
             DG.TiroJuan = 1;
        }
        if (other.CompareTag("BalonComprobacionRoberto"))
        {
            // El balón colisionó con este objeto
            // Aquí puedes agregar el código para manejar la colisión
             Debug.Log("Tiro Exitoso de Roberto");
             balonRoberto.tag = "Untagged";
             DG.TiroRoberto = 1;
        }
    }
}
