using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string email;
    public bool first_ex;
    public bool second_ex;
    public bool third_ex;
    public string time_minutes;
    public string[] questions;
}

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
    public string totalTime = "00:00:00";
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

    public GameObject Vistapanel;
    public GameObject panel;

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

        // Obtener el tiempo
        totalTime = PlayerPrefs.GetString("tiempo");
        //Obtener el email
        string email = PlayerPrefs.GetString("email");

        Debug.Log("Tiempo total: " + totalTime);

        string[] dataTiros = new string[] {
            VelocidadInicialD.ToString(),
            AnguloD.ToString(),
            AlturaD.ToString(),
            DistanciaD.ToString(),
            VelocidadInicialJ.ToString(),
            AnguloJ.ToString(),
            AlturaJ.ToString(),
            DistanciaJ.ToString(),
            VelocidadInicialR.ToString(),
            AnguloR.ToString(),
            AlturaR.ToString(),
            DistanciaR.ToString()
        };

        // Inicializa los datos
        UserData myData = new UserData
        {
            email = email,
            first_ex = IntToBool(LanzamientoD),
            second_ex = IntToBool(LanzamientoJ),
            third_ex = IntToBool(LanzamientoR),
            time_minutes = totalTime,
            questions = dataTiros
        };

        // // Inicializa los datos
        // UserData myData = new UserData
        // {
        //     email = "jorge_enrique.barragan2@uao.edu.co",
        //     first_ex = IntToBool(LanzamientoD),
        //     second_ex = IntToBool(LanzamientoJ),
        //     third_ex = IntToBool(LanzamientoR),
        //     time_minutes = totalTime,
        //     questions = dataTiros
        // };

        // URL del endpoint al que quieres enviar el JSON
        // string url = "http://localhost:3000/api/grades?userId=jorge_enrique.barragan2@uao.edu.co";
        string url = "http://localhost:3000/api/grades?userId=" + email;

        string jsonData = JsonUtility.ToJson(myData);
        Debug.Log("JSON: " + jsonData);
        StartCoroutine(PostRequest(url, jsonData));
    }


    IEnumerator PostRequest(string uri, string json)
    {
        // Convertir el JSON a bytes para enviar
        byte[] jsonToSend = Encoding.UTF8.GetBytes(json);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        // Enviar la petición
        yield return webRequest.SendWebRequest();

        // Manejar la respuesta
        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + webRequest.error);
        }
        else
        {
            Debug.Log("Response: " + webRequest.downloadHandler.text);
        }
    }

    public bool IntToBool(int value)
    {
        if (value == 0)
        {
            return false;
        }
        else if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
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

        Vistapanel.SetActive(false);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void RetroalimentacionDiego()
    {
        VistaJuan.SetActive(false);
        PosicionJuan.SetActive(false);
        PIJuan.SetActive(false);
        BalonJuan.SetActive(false);

        VistaDiego.SetActive(true);
        PosicionDiego.SetActive(true);
        PIDiego.SetActive(true);
        BalonDiego.SetActive(true);
    }
    public void RetroalimentacionRoberto()
    {
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

    public void RetroalimentacionPanel()
    {
        VistaJuan.SetActive(false);
        PosicionJuan.SetActive(false);
        PIJuan.SetActive(false);
        BalonJuan.SetActive(false);

        VistaDiego.SetActive(false);
        PosicionDiego.SetActive(false);
        PIDiego.SetActive(false);
        BalonDiego.SetActive(false);

        VistaRoberto.SetActive(false);
        PosicionRoberto.SetActive(false);
        PIRoberto.SetActive(false);
        BalonRoberto.SetActive(false);

        Vistapanel.SetActive(true);
        panel.SetActive(true);
    }
}
