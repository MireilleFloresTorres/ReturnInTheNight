using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Reiniciar()
    {
        string nivel = PlayerPrefs.GetString("UltimoNivel", "MireScene");
        SceneManager.LoadScene(nivel);
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("RogerScene");
    }
}