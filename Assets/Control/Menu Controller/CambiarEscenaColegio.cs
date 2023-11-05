using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarEscenaColegio : MonoBehaviour
{
    public Button irAColegioButton;

    void Start()
    {
        if (irAColegioButton != null)
        {
            irAColegioButton.onClick.AddListener(IrAColegio);
        }
        else
        {
            Debug.LogError("Botón de ir a Colegio no asignado en el Inspector de Unity.");
        }
    }

    void IrAColegio()
    {
        // Cambiar a la escena "Colegio"
        SceneManager.LoadScene("Colegio");
    }
}
