using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public RectTransform creditos;

    public float velocidad = 50f;

    private Vector2 posicionInicial;

    void Start()
    {
        posicionInicial = creditos.anchoredPosition;
    }

    void Update()
    {
        creditos.anchoredPosition += Vector2.up * velocidad * Time.deltaTime;
    }

    public void ReiniciarCreditos()
    {
        creditos.anchoredPosition = posicionInicial;
    }
}