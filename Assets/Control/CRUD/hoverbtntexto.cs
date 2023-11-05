using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class hoverbtntexto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color normalColor = Color.white;
    public Color hoverColor = Color.green;

    private TextMeshProUGUI textMesh;
    private Image buttonImage;

    void Start()
    {
        // Obtén la referencia al componente TextMeshProUGUI dentro del botón
        textMesh = GetComponentInChildren<TextMeshProUGUI>();

        // Obtén la referencia al componente Image del botón
        //buttonImage = GetComponent<Image>();

        // Establece el color normal al inicio
        //buttonImage.color = normalColor;
        textMesh.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambia el color al color de "hover" cuando el mouse entra
        //buttonImage.color = hoverColor;
        textMesh.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revierte al color normal cuando el mouse sale
       // buttonImage.color = normalColor;
        textMesh.color = normalColor;
    }
}
