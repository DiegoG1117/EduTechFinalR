using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ControlVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isPaused = false; // Variable para rastrear el estado de pausa

    private void Start()
    {
        // Asegúrate de asignar el componente VideoPlayer desde el Inspector
        if (videoPlayer == null)
        {
            Debug.LogError("Asigna el componente VideoPlayer desde el Inspector.");
            return;
        }

        // Agrega un Listener al botón para detectar clics
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(TogglePausaVideo);
        }
        else
        {
            Debug.LogError("No se encontró un componente Button en el objeto de imagen.");
        }

    }

    private void TogglePausaVideo()
    {
        if (isPaused)
        {
            // Si está pausado, reanuda el video
            videoPlayer.Play();
        }
        else
        {
            // Si no está pausado, pausa el video
            videoPlayer.Pause();
        }

        // Cambia el estado de pausa
        isPaused = !isPaused;

      
    }

}
