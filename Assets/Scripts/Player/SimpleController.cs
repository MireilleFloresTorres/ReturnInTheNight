using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class SimpleFPSController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 10f; // Ajustado: el New Input System da valores más grandes
    public float gravity = -9.81f;

    float xRotation = 0f;
    float yVelocity;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        Camera.main.transform.localPosition = new Vector3(0f, 1.75f, 0f);
    }

    void Update()
    {
        // --- Movimiento horizontal ---
        Vector2 moveInput = Gamepad.current != null
            ? Gamepad.current.leftStick.ReadValue()
            : Vector2.zero;

        // Teclado (WASD / flechas)
        float x = 0f, z = 0f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x += 1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x -= 1f;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) z += 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) z -= 1f;

        // Combina teclado + gamepad
        x += moveInput.x;
        z += moveInput.y;

        Vector3 move = transform.right * x + transform.forward * z;

        // --- Gravedad ---
        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;

        yVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * speed;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);

        // --- Mouse ---
        // --- Mouse ---
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        if (mouseDelta.sqrMagnitude > 0.01f)
        {
            // Multiplica por Time.deltaTime para que sea independiente del framerate
            float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
            float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}