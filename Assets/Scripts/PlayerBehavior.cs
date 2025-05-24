using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : EntityBehavior
{
    private readonly Player player = new Player();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.EntitySoundManager = GameObject.Find("EntitySoundManager")
            .GetComponent<EntitySoundManager>();

        player.MoveAction = InputSystem.actions.FindAction("Move");
        player.JumpAction = InputSystem.actions.FindAction("Jump");
        player.LookAction = InputSystem.actions.FindAction("Look");
        player.SprintAction = InputSystem.actions.FindAction("Sprint");

        player.PlayerCameraGameObject = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravityToSelf();

        OnSprintPressed();
        OnMovePressed();
        OnAttackPressed();

        LookAt();
    }

    void Move(Vector3 normalizedMoveDirection)
    {
        transform.Translate(player.CurrentSprintValue * player.MoveSpeed * Time.deltaTime * normalizedMoveDirection);
        //SoundBehavior.ProjectSound(name);

        Debug.Log("Player ms: " + player.MoveSpeed);
        Debug.Log("Player sprint: " + player.CurrentSprintValue);
        Debug.Log("Current Speed: " + player.CurrentSprintValue * player.MoveSpeed * Time.deltaTime * normalizedMoveDirection);
    }

    void Sprint()
    {
        // Increase SprintTimer up to TimeToMaxSprint
        // Decrease SprintTimer down to 0, but use TimeToStopSprint for the rate
        if (player.SprintAction.IsPressed())
            player.SprintTimer += Time.deltaTime;
        else
            player.SprintTimer -= Time.deltaTime * (player.TimeToMaxSprint / player.TimeToStopSprint);

        player.SprintTimer = Mathf.Clamp(player.SprintTimer, 0, player.TimeToMaxSprint);
        player.CurrentSprintValue = Mathf.Lerp(1f, player.SprintMultiplier, player.SprintTimer / player.TimeToMaxSprint);
    }

    void LookAt()
    {
        // Get look values from the Input System
        Vector2 lookValue = player.LookAction.ReadValue<Vector2>();

        // Rotate the camera up and down
        Vector3 newPlayerRotation = transform.localEulerAngles;
        newPlayerRotation.y += lookValue.x;
        transform.localRotation = Quaternion.Euler(0, newPlayerRotation.y, 0);

        // Rotate the player model and child camera left and right
        Vector3 newCameraRotation = player.PlayerCameraGameObject.transform.localEulerAngles;
        newCameraRotation.x -= lookValue.y;
        Mathf.Clamp(newCameraRotation.x, -90, 90);
        player.PlayerCameraGameObject.transform.localRotation = Quaternion.Euler(newCameraRotation.x, 0, 0);
    }

    void OnMovePressed()
    {
        // This gets (x,y) values from the Input System
        Vector2 moveValue = player.MoveAction.ReadValue<Vector2>();

        // We need to convert (x,y) to (x,z) for 3D movement
        Vector3 moveValue3d = new Vector3(moveValue.x, 0, moveValue.y);

        Debug.Log(moveValue3d);
        Move(moveValue3d);
    }

    void OnSprintPressed()
    {
        Vector2 moveValue = player.MoveAction.ReadValue<Vector2>();
        Vector3 moveValue3d = new Vector3(moveValue.x, 0, moveValue.y);

        bool isPlayerMovingForward = Vector3.Angle(transform.forward, moveValue3d) < Mathf.PI * 0.5f;
        if (IsGrounded() && isPlayerMovingForward)
        {
            Sprint();
        }
    }

    void OnAttackPressed()
    {

    }
}
