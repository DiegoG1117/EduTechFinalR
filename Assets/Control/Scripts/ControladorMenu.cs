using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{

    // CAMARAS DE VISION DE LAS PRACTICAS
    public GameObject VistaMenu;
    public GameObject ControladorJuan;
    public GameObject ControladorDiego;
    public GameObject ControladorRoberto;

    public GameObject CansadoJuan;
    public GameObject CansadoDiego;
    public GameObject CansadoRoberto;

    public GameObject MenuJuan;
    public GameObject MenuDiego;
    public GameObject MenuRoberto;

    public GameObject BtnJuan;
    public GameObject BtnDiego;
    public GameObject BtnRoberto;

    public bool eJuan = false;
    public bool eDiego = false;
    public bool eRoberto = false;

    public EnviandoDatos EDatos;

    public GameObject VistaJuan;
    public GameObject VistaDiego;
    public GameObject VistaRoberto;

    public GameObject objetoControlado; // El objeto que se encenderá o apagará
    public TextMeshPro textoEncima; // El TextMeshProUGUI que cambiará de color

    private bool objetoEncendido;
    public Color colorNormal = Color.white; // Color normal del texto
    public Color colorHover = Color.red; // Color cuando el cursor está encima

    public AudioSource audioJuan;
    public AudioSource audioDiego;
    public AudioSource audioRoberto;

    public GameObject BtnAudioJuan;
    public GameObject BtnAudioDiego;
    public GameObject BtnAudioRoberto;

    public GameObject CamaraJuan;
    public GameObject CamaraDiego;
    public GameObject CamaraRoberto;

    public GameObject ventanaEmergente;


    private void Start()
    {
        ventanaEmergente.SetActive(false);

        VistaMenu.SetActive(true);
        ControladorJuan.SetActive(true);
        ControladorDiego.SetActive(true);
        ControladorRoberto.SetActive(true);

        CamaraJuan.SetActive(false);
        CamaraDiego.SetActive(false);
        CamaraRoberto.SetActive(false);

        CansadoJuan.SetActive(false);
        CansadoDiego.SetActive(false);
        CansadoRoberto.SetActive(false);

        MenuJuan.SetActive(true);
        MenuDiego.SetActive(true);
        MenuRoberto.SetActive(true);

        VistaJuan.SetActive(false);
        VistaDiego.SetActive(false);
        VistaRoberto.SetActive(false);


        BtnJuan.SetActive(true);
        BtnDiego.SetActive(true);
        BtnRoberto.SetActive(true);
        
        BtnAudioJuan.SetActive(false);
        BtnAudioDiego.SetActive(false);
        BtnAudioRoberto.SetActive(false);

        audioJuan.enabled = false;
        audioDiego.enabled = false;
        audioRoberto.enabled = false;

    }

    private void Update()
    {
            eJuan = EDatos.ejercicioJuan;
            eDiego = EDatos.ejercicioDiego;
            eRoberto = EDatos.ejercicioRoberto;

        if (eJuan == true)
        {
            CansadoJuan.SetActive(true);
            MenuJuan.SetActive(false);
            BtnJuan.SetActive(false);
            BtnAudioJuan.SetActive(true);
            
        }

        if (eDiego == true)
        {
            CansadoDiego.SetActive(true);
            MenuDiego.SetActive(false);
            BtnDiego.SetActive(false);
            BtnAudioDiego.SetActive(true);
            
        }

        if (eRoberto == true)
        {
            CansadoRoberto.SetActive(true);
            MenuRoberto.SetActive(false);
            BtnRoberto.SetActive(false);
            BtnAudioRoberto.SetActive(true);
            
        }
            
    }

    public void Menu()
    {
       
        VistaMenu.SetActive(true);
        ControladorJuan.SetActive(false);
        ControladorDiego.SetActive(false);
        ControladorRoberto.SetActive(false);
        
        CamaraJuan.SetActive(false);
        CamaraDiego.SetActive(false);
        CamaraRoberto.SetActive(false);

        VistaJuan.SetActive(false);
        VistaDiego.SetActive(false);
        VistaRoberto.SetActive(false);

        ventanaEmergente.SetActive(false);
        
    }

    public void PracticaJuan()
    {
       
        VistaMenu.SetActive(false);
        ControladorJuan.SetActive(true);
        ControladorDiego.SetActive(false);
        ControladorRoberto.SetActive(false);

        CamaraJuan.SetActive(true);
        CamaraDiego.SetActive(false);
        CamaraRoberto.SetActive(false);

        VistaJuan.SetActive(true);
        VistaDiego.SetActive(false);
        VistaRoberto.SetActive(false);

        ventanaEmergente.SetActive(true);
    }
    public void PracticaDiego()
    {
       
        VistaMenu.SetActive(false);
        ControladorJuan.SetActive(false);
        ControladorDiego.SetActive(true);
        ControladorRoberto.SetActive(false);

        CamaraJuan.SetActive(false);
        CamaraDiego.SetActive(true);
        CamaraRoberto.SetActive(false);

        VistaJuan.SetActive(false);
        VistaDiego.SetActive(true);
        VistaRoberto.SetActive(false);

        ventanaEmergente.SetActive(true);
    }
    public void PracticaRoberto()
    {
       
        VistaMenu.SetActive(false);
        ControladorJuan.SetActive(false);
        ControladorDiego.SetActive(false);
        ControladorRoberto.SetActive(true);

        CamaraJuan.SetActive(false);
        CamaraDiego.SetActive(false);
        CamaraRoberto.SetActive(true);

        VistaJuan.SetActive(false);
        VistaDiego.SetActive(false);
        VistaRoberto.SetActive(true);

        ventanaEmergente.SetActive(true);
    }
       public void OnMouseEnter()
    {
        // Este método se llama cuando el cursor entra en el collider del objeto
        textoEncima.color = colorHover; // Cambia el color cuando el cursor está encima
    }

    public void OnMouseExit()
    {
        // Este método se llama cuando el cursor sale del collider del objeto
        textoEncima.color = colorNormal; // Restaura el color normal
    }

    public void ReproducirAudioJ()
    {
        audioJuan.enabled = true;        
        // Reproduce el AudioClip
        audioJuan.Play();
    }
    public void ReproducirAudioD()
    {
         audioDiego.enabled = true; 
        // Reproduce el AudioClip
        audioDiego.Play();
        
    }
    public void ReproducirAudioR()
    {
          audioRoberto.enabled = true; 
        // Reproduce el AudioClip
        audioRoberto.Play();
    }
    public void CargarEscenaColegio()
    {
        SceneManager.LoadScene("Colegio");
    }
        public void CargarEscenaEstadio()
    {
        SceneManager.LoadScene("EscenaStadio");
    }
    public void cerrarVentanaEmergente()
    {
      ventanaEmergente.SetActive(false);
    }

}
 