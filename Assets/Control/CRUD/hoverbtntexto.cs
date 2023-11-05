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
        // Obt�n la referencia al componente TextMeshProUGUI dentro del bot�n
        textMesh = GetComponentInChildren<TextMeshProUGUI>();

        // Obt�n la referencia al componente Image del bot�n
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
