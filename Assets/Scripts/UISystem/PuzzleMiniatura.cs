using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleMiniatura : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefabPiezaGrande;
    public RectTransform areaTablero;

    private bool yaUsada = false;
    private GameObject piezaTemporal; // Pieza que se arrastra visualmente

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (yaUsada) return;

        // Crea la pieza grande y la pone encima de todo en el Canvas
        Canvas canvas = GetComponentInParent<Canvas>();
        piezaTemporal = Instantiate(prefabPiezaGrande, canvas.transform);
        piezaTemporal.GetComponent<RectTransform>().position =
            eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (piezaTemporal == null) return;

        // La pieza sigue al mouse
        piezaTemporal.GetComponent<RectTransform>().position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (piezaTemporal == null) return;

        if (RectTransformUtility.RectangleContainsScreenPoint(
            areaTablero, eventData.position, eventData.pressEventCamera))
        {
            piezaTemporal.transform.SetParent(areaTablero);

            // Reset de escala + tamaño
            piezaTemporal.transform.SetParent(areaTablero);

            // En lugar de sizeDelta, escala directamente
            piezaTemporal.transform.localScale = new Vector3(3f, 3f, 1f);

            yaUsada = true;
            GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
            Destroy(piezaTemporal);
        }

        piezaTemporal = null;
    }
}