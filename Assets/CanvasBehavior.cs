using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasBehavior : MonoBehaviour
{
    public Rigidbody playerRb;

    public TextMeshProUGUI TextBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextBox.text = $"3D Velocity: {playerRb.linearVelocity}\n" +
            $"Ground Speed: {new Vector3(playerRb.linearVelocity.x, playerRb.linearVelocity.z).magnitude}\n" +
            $"Move Input: {InputSystem.actions.FindAction("Move").ReadValue<Vector2>()}\n" +
            $"Is Sprinting: {InputSystem.actions.FindAction("Sprint").ReadValue<float>()}\n";
    }
}
