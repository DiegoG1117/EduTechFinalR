using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorFallidos : MonoBehaviour
{

    public GameObject balonDiego;
    public GameObject balonJuan;
    public GameObject balonRoberto;
    public DatosGuardados DG;

void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TiroFallido") && gameObject.CompareTag("BalonComprobacionDiego"))
        {
            balonDiego.tag = "Untagged";
            Debug.Log("El lanzamiento fue fallido.");
            DG.TiroDiego = 0;
        }

        if (collision.gameObject.CompareTag("TiroFallido") && gameObject.CompareTag("BalonComprobacionJuan"))
        {
            balonJuan.tag = "Untagged";
            Debug.Log("El lanzamiento fue fallido.");
            DG.TiroJuan = 0;
        }
        if (collision.gameObject.CompareTag("TiroFallido") && gameObject.CompareTag("BalonComprobacionRoberto"))
        {
            balonRoberto.tag = "Untagged";
            Debug.Log("El lanzamiento fue fallido.");
            DG.TiroRoberto = 0;
        }
    }

}
