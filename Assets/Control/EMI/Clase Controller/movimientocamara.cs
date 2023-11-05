using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientocamara : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 2.0f;

    private Transform camaraTransform;

    private void Start()
    {
        // Obtén la transformación de la cámara
        camaraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Movimiento con las teclas WASD
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Movimiento vertical
        float movimientoUpDown = Input.GetAxis("Mouse ScrollWheel") * velocidadMovimiento * Time.deltaTime;

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoUpDown, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);

        // Rotación de la cámara
        float rotacionX = Input.GetAxis("Mouse X") * velocidadRotacion; // Cambio Mouse X a rotación en el eje X
        float rotacionY = Input.GetAxis("Mouse Y") * velocidadRotacion; // Agregar rotación en el eje Y
        camaraTransform.Rotate(-rotacionY, rotacionX, 0); // Usar -rotacionY para invertir la rotación en Y
    }
}





