using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene("MireScene");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("RogerScene");
    }
}