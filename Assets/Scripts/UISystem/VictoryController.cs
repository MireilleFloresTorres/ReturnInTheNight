using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    [Header("Escena del Main Menu")]
    public string escenaMenuPrincipal = "RogerScene";

    // Bandera que indica si al cargar RogerScene debe abrir Créditos
    public static bool abrirCreditosAlCargar = false;

    public void IrAlMenuPrincipal()
    {
        abrirCreditosAlCargar = false;
        SceneManager.LoadScene(escenaMenuPrincipal);
    }

    public void IrACreditos()
    {
        abrirCreditosAlCargar = true;
        SceneManager.LoadScene(escenaMenuPrincipal);
    }
}