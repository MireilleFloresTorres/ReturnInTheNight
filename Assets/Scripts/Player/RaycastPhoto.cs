using UnityEngine;
using UnityEngine.InputSystem;

public class RecogerFoto : MonoBehaviour
{
    public float alcance = 2.5f;          // Distancia máxima para recoger
    public PuzzleManager puzzleManager;   // Arrastra el PuzzleManager aquí

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            IntentarRecoger();
        }
    }

    void IntentarRecoger()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));

        Debug.DrawRay(ray.origin, ray.direction * alcance, Color.red, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, alcance))
        {
            Debug.Log("Golpeó: " + hit.collider.name + " Tag: " + hit.collider.tag);

            if (hit.collider.CompareTag("Foto"))
            {
                hit.collider.gameObject.SetActive(false);
                puzzleManager.PiezaEncontrada();
            }
        }
        else
        {
            Debug.Log("Raycast no golpeó nada");
        }
    }
}