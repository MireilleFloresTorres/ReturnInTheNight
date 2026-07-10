using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleMiniatura : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefabPiezaGrande;
    public RectTransform areaTablero;
    public Vector2 tamañoGrande = new Vector2(480f, 480f);

    private bool yaUsada = false;
    private GameObject piezaTemporal;
    private Canvas canvasRaiz;

    void Start()
    {
        canvasRaiz = GetComponentInParent<Canvas>().rootCanvas;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (yaUsada) return;

        piezaTemporal = Instantiate(prefabPiezaGrande, canvasRaiz.transform);
        RectTransform rt = piezaTemporal.GetComponent<RectTransform>();
        rt.position = eventData.position;
        rt.sizeDelta = new Vector2(80f, 80f); // Tamaño mientras arrastras
        piezaTemporal.transform.localScale = Vector3.one;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (piezaTemporal == null) return;
        piezaTemporal.GetComponent<RectTransform>().position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (piezaTemporal == null) return;

        if (RectTransformUtility.RectangleContainsScreenPoint(
            areaTablero, eventData.position, eventData.pressEventCamera))
        {
            // Mueve al tablero y escala grande
            piezaTemporal.transform.SetParent(areaTablero, false);
            RectTransform rt = piezaTemporal.GetComponent<RectTransform>();
            rt.anchoredPosition = Vector2.zero;
            rt.sizeDelta = tamañoGrande;
            piezaTemporal.transform.localScale = Vector3.one;

            yaUsada = true;
            GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);

            PuzzleManager.Instance.PiezaColocadaEnTablero();
        }
        else
        {
            Destroy(piezaTemporal);
        }

        piezaTemporal = null;
    }
}