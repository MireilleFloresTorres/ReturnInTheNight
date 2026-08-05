using UnityEngine;
using UnityEngine.InputSystem;

public class RecogerFoto : MonoBehaviour
{
    public float alcance = 2.5f;
    public PuzzleManager puzzleManager;

    private Cama camaActual = null;

    void Update()
    {
        ManejarRaycast();

        if (Keyboard.current.qKey.wasPressedThisFrame)
            IntentarInteractuar();

        if (Keyboard.current.fKey.wasPressedThisFrame && camaActual != null)
            AnomalyManager.Instance.IntentarDormir();
    }

    void ManejarRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out RaycastHit hit, alcance))
        {
            // Cama
            if (hit.collider.CompareTag("Cama"))
            {
                Cama cama = hit.collider.GetComponent<Cama>();
                if (camaActual != cama)
                {
                    if (camaActual != null) camaActual.MostrarPista(false);
                    camaActual = cama;
                    camaActual.MostrarPista(true);
                }
                return;
            }
        }

        // Si no apunta a la cama, oculta la pista
        if (camaActual != null)
        {
            camaActual.MostrarPista(false);
            camaActual = null;
        }
    }

    void IntentarInteractuar()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out RaycastHit hit, alcance))
        {
            // Foto
            if (hit.collider.CompareTag("Foto"))
            {
                hit.collider.gameObject.SetActive(false);
                puzzleManager.PiezaEncontrada();
            }

            // Anomalía sin diálogo
            if (hit.collider.CompareTag("Anomalia"))
            {
                Anomalia anomalia = hit.collider.GetComponent<Anomalia>();
                if (anomalia != null)
                    anomalia.Encontrar();
            }

            // Anomalía con diálogo
            if (hit.collider.CompareTag("AnomaliaDialogo"))
            {
                AnomaliaDialogo anomalia = hit.collider.GetComponent<AnomaliaDialogo>();
                if (anomalia != null)
                    anomalia.Activar();
            }
        }
    }
}