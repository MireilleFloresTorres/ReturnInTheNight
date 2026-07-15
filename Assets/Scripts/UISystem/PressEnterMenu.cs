using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PressEnterMenu : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("RogerScene");
        }
    }
}