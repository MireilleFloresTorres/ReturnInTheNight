using UnityEngine;
using TMPro;

public class BlinkText : MonoBehaviour
{
    public float velocidad = 2f;
    public float escala = 0.05f;

    private TextMeshProUGUI texto;
    private Color color;
    private Vector3 escalaInicial;

    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        color = texto.color;
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * velocidad, 1f);

        // Transparencia
        color.a = Mathf.Lerp(0.35f, 1f, t);
        texto.color = color;

        // Escala
        transform.localScale = escalaInicial * (1 + t * escala);
    }
}