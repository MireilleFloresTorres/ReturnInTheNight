using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoManager : MonoBehaviour
{
    public static DialogoManager Instance;

    [Header("Panel")]
    public GameObject panelDialogo;
    public TextMeshProUGUI txtDialogo;
    public Image imgDialogo;
    public Button btnCerrar;

    void Awake() => Instance = this;

    void Start()
    {
        panelDialogo.SetActive(false);
    }

    public void MostrarDialogo(string texto, Sprite imagen)
    {
        panelDialogo.SetActive(true);
        txtDialogo.text = texto;

        // La imagen es opcional, no todas las anomalías la tienen
        if (imagen != null)
        {
            imgDialogo.sprite = imagen;
            imgDialogo.gameObject.SetActive(true);
        }
        else
        {
            imgDialogo.gameObject.SetActive(false);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}