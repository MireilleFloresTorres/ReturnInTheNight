using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI txtDia;

    void Start()
    {
        // Pequeño delay para asegurarse que DayManager ya existe
        Invoke("ActualizarDia", 0.1f);
    }

    void ActualizarDia()
    {
        if (DayManager.Instance != null)
            txtDia.text = "Día: " + DayManager.Instance.GetDia() + "/" + DayManager.Instance.GetTotalDias();
        else
            txtDia.text = "Día: 0/3";
    }
}