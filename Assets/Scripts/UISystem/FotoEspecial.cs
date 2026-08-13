using UnityEngine;

public class FotoEspecial : MonoBehaviour
{
    private void Start()
    {
        // Si ya fue recogida anteriormente, la eliminamos
        if (PlayerPrefs.GetInt("FotoEspecialRecogida", 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void RecogerFoto()
    {
        PlayerPrefs.SetInt("FotoEspecialRecogida", 1);
        PlayerPrefs.Save();

        gameObject.SetActive(false);
    }
}