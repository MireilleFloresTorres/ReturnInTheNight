using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI txtDia;
    public TextMeshProUGUI txtFotos;

    void Start()
    {
        Invoke("ActualizarTodo", 0.1f);
    }

    void Update()
    {
        ActualizarTodo();
    }

    void ActualizarTodo()
    {
        if (DayManager.Instance == null) return;

        if (txtDia != null)
            txtDia.text = "Día " + DayManager.Instance.GetDia() + " - " + DayManager.Instance.GetTotalDias();

        if (txtFotos != null)
            txtFotos.text = DayManager.Instance.GetFotos() + " - " + DayManager.Instance.GetTotalFotos();
    }
}