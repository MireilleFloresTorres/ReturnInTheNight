using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PanelPCompletadoController : MonoBehaviour
{
    [Header("Panel a controlar")]
    public GameObject panelPCompletado;

    [Header("Escena destino")]
    public string escenaVictoria = "VictoryEscene";

    void Update()
    {
        if (panelPCompletado != null && panelPCompletado.activeSelf)
        {
            if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(escenaVictoria);
            }
        }
    }
}