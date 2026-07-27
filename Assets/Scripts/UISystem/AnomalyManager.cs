using UnityEngine;
using UnityEngine.SceneManagement;

public class AnomalyManager : MonoBehaviour
{
    public static AnomalyManager Instance;

    [Header("Configuración")]
    public int totalAnomalias = 10;
    public int minimoParaGanar = 5;

    private int anomaliasEncontradas = 0;

    void Awake() => Instance = this;

    public void RegistrarAnomalia()
    {
        anomaliasEncontradas++;
        Debug.Log("Anomalías encontradas: " + anomaliasEncontradas);
    }

    public void IntentarDormir()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (anomaliasEncontradas >= minimoParaGanar)
        {
            Debug.Log("Antes de AvanzarDia: " + DayManager.Instance.GetDia());
            DayManager.Instance.AvanzarDia();
            Debug.Log("Después de AvanzarDia: " + DayManager.Instance.GetDia());
            CargarSiguienteEscena();
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void CargarSiguienteEscena()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscena = escenaActual + 1;

        if (siguienteEscena >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("VictoriaScene"); 
        }
        else
        {
            SceneManager.LoadScene(siguienteEscena);
        }
    }
}