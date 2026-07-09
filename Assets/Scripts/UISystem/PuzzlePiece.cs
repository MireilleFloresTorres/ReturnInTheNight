using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PiezaArrastrable : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
    public float velocidadTeclas = 200f;
    public float velocidadRotacion = 90f; // Grados por segundo al rotar

    private RectTransform rect;
    private Canvas canvas;
    private static PiezaArrastrable piezaActiva;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (piezaActiva != this) return;

        bool shift = Keyboard.current.leftShiftKey.isPressed ||
                     Keyboard.current.rightShiftKey.isPressed;

        if (shift)
        {
            // Shift + flechas = rotar
            if (Keyboard.current.leftArrowKey.isPressed)
                rect.Rotate(0f, 0f, velocidadRotacion * Time.unscaledDeltaTime);

            if (Keyboard.current.rightArrowKey.isPressed)
                rect.Rotate(0f, 0f, -velocidadRotacion * Time.unscaledDeltaTime);
        }
        else
        {
            // Solo flechas = mover
            Vector2 input = Vector2.zero;

            if (Keyboard.current.leftArrowKey.isPressed) input.x = -1f;
            if (Keyboard.current.rightArrowKey.isPressed) input.x = 1f;
            if (Keyboard.current.upArrowKey.isPressed) input.y = 1f;
            if (Keyboard.current.downArrowKey.isPressed) input.y = -1f;

            rect.anchoredPosition += input * velocidadTeclas * Time.unscaledDeltaTime;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        piezaActiva = this;
        transform.SetAsLastSibling();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        piezaActiva = this;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}