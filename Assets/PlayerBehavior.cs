using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;

    Camera playerCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");

        playerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        MoveCamera();
        LookAt();
    }

    void Move()
    {
        // This gets (x,y) values from the Input System
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // We need to convert (x,y) to (x,z) for 3D movement
        Vector3 moveValue3d = new Vector3(moveValue.x, 0, moveValue.y);
        transform.Translate(moveValue3d * Time.deltaTime);

        if (jumpAction.IsPressed())
        {
            Debug.Log("Jumping");
        }
    }

    void MoveCamera()
    {
        playerCamera.transform.position = transform.position;
    }
    void LookAt()
    {
        // Get look values from the Input System
        Vector2 lookValue = lookAction.ReadValue<Vector2>();

        Vector3 newPlayerRotation = transform.localEulerAngles;
        newPlayerRotation.y += lookValue.x;
        Debug.Log(newPlayerRotation.y);
        transform.localRotation = Quaternion.AngleAxis(newPlayerRotation.y, Vector3.up);

        Vector3 newCameraRotation = playerCamera.transform.localEulerAngles;
        newCameraRotation.x -= lookValue.y;
        //Debug.Log(newCameraRotation.x);
        //newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, 0, 11);
        playerCamera.transform.localRotation = Quaternion.AngleAxis(newCameraRotation.x, Vector3.right);
    }
}
