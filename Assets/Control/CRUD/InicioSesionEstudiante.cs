using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement; // Agrega esta l�nea

public class InicioSesionEstudiante : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public Button iniciarSesionButton;
    public GameObject PanelLogin;

    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text resultadoTexto;

    public GameObject panelError;

    void Start()
    {
        if (iniciarSesionButton != null)
        {
            iniciarSesionButton.onClick.AddListener(IniciarSesionEstudiante);
        }
        else
        {
            Debug.LogError("Bot�n de inicio de sesi�n no asignado en el Inspector de Unity.");
        }
    }

    void IniciarSesionEstudiante()
    {
        string email = UnityWebRequest.EscapeURL(emailInput.text);
        string password = UnityWebRequest.EscapeURL(passwordInput.text);

        StartCoroutine(VerificarCredenciales(email, password));
    }

    IEnumerator VerificarCredenciales(string email, string password)
    {
        // Construir la URL con los par�metros de inicio de sesi�n
        string url = $"https://edu-tech-git-dev-santiagomc2k16.vercel.app/api/users/auth?email={email}&password={password}";

        string correoIngresado = inputField.text;

        // Realizar la solicitud GET
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error al iniciar sesi�n. C�digo: {request.responseCode}. Detalles: {request.error}");
            resultadoTexto.text = "Correo o contrase�a incorrecta ";
            resultadoTexto.color = Color.red;

            panelError.SetActive(true);
        }
        else if (correoIngresado.EndsWith("@uao.edu.co"))
        {
            PlayerPrefs.SetString("email", correoIngresado);
            PlayerPrefs.Save();
            resultadoTexto.text = "Correo v�lido";
            resultadoTexto.color = Color.green;


            Debug.Log("Inicio de sesi�n exitoso");

            // Desactivar el PanelLogin
            PanelLogin.SetActive(false);

            // Cambiar a la escena "colegio"
            SceneManager.LoadScene("Gimnasio de baloncesto 1");

            // Agregar mensaje en consola
            Debug.Log("�Usuario ha iniciado sesi�n exitosamente!");

            // Generar y guardar JSON en el escritorio
            string jsonContent = $"{{\"email\": \"{email}\", \"password\": \"{password}\"}}";
            string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "UsuarioSesion.json");
            File.WriteAllText(filePath, jsonContent);

            Debug.Log($"JSON guardado en: {filePath}");
        }
        else
        {
            Debug.LogError($"Inicio de sesi�n fallido tiene que ser uao.edu.co. C�digo: {request.responseCode}. Detalles: {request.downloadHandler.text}");
            resultadoTexto.text = "El correo debe ser @uao.edu.co";
            resultadoTexto.color = Color.red;
            panelError.SetActive(true);
        }


    }
}
