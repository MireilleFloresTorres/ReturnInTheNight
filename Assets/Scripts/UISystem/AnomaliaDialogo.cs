using UnityEngine;

public class AnomaliaDialogo : MonoBehaviour
{
    [Header("Diálogo")]
    [TextArea(2, 4)]
    public string textoDialogo;
    public Sprite imagenDialogo; // Opcional, puede quedar vacío

    private bool yaActivada = false;

    public void Activar()
    {
        if (yaActivada) return;
        yaActivada = true;

        // Registra la anomalía
        AnomalyManager.Instance.RegistrarAnomalia();

        // Muestra el diálogo
        DialogoManager.Instance.MostrarDialogo(textoDialogo, imagenDialogo);
    }
}