using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RawImage rawImage;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.gray;

    void Start()
    {
        // Asegúrate de que la RawImage está asignada
        if (rawImage == null)
        {
            Debug.LogError("¡Asigna la RawImage en el Inspector de Unity!");
            return;
        }

        // Configura el color normal al inicio
        rawImage.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambia el color al color de "hover" cuando el mouse entra
        rawImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revierte al color normal cuando el mouse sale
        rawImage.color = normalColor;
    }
}
