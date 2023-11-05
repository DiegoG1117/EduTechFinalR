using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class CerrarSesion : MonoBehaviour
{
    public Button cerrarSesionButton;

    void Start()
    {
        if (cerrarSesionButton != null)
        {
            cerrarSesionButton.onClick.AddListener(CerrarSesionUsuario);
        }
        else
        {
            Debug.LogError("Botón de cerrar sesión no asignado en el Inspector de Unity.");
        }
    }

    void CerrarSesionUsuario()
    {
        StartCoroutine(CerrarSesionRequest());
    }

    IEnumerator CerrarSesionRequest()
    {
        // URL para cerrar la sesión
        string url = "https://edu-tech-git-dev-santiagomc2k16.vercel.app/api/users/logout";

        // Realizar la solicitud GET
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error al cerrar sesión. Código: {request.responseCode}. Detalles: {request.error}");
        }
        else
        {
            Debug.Log("Sesión cerrada exitosamente");

            // Cambiar a la escena "Registro_Login"
            SceneManager.LoadScene("Registro_Login");
        }
    }
}
