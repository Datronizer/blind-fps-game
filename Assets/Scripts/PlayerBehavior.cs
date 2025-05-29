using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : EntityBehavior
{
    protected Player player = new Player();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entity = player;

        player.Rb = GetComponent<Rigidbody>();

        player.MoveAction = InputSystem.actions.FindAction("Move");
        player.JumpAction = InputSystem.actions.FindAction("Jump");
        player.LookAction = InputSystem.actions.FindAction("Look");
        player.SprintAction = InputSystem.actions.FindAction("Sprint");

        player.PlayerCameraGameObject = GameObject.Find("PlayerCamera");
        player.EntitySoundManager = GameObject.Find("EntitySoundManager")
            .GetComponent<EntitySoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ClampRestingVelocity();

        OnSprintPressed();
        OnMovePressed();
        OnAttackPressed();
        OnJumpClicked();

        LookAt();
    }

    protected override void Sprint()
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

        // Rotate the player model and child camera left and right
        Vector3 newPlayerRotation = transform.localEulerAngles;
        newPlayerRotation.y += lookValue.x;
        transform.localRotation = Quaternion.Euler(0, newPlayerRotation.y, 0);

        // Rotate the camera left up and down
        Vector3 newCameraRotation = player.PlayerCameraGameObject.transform.localEulerAngles;
        newCameraRotation.x -= lookValue.y;
        player.PlayerCameraGameObject.transform.localRotation = Quaternion.Euler(newCameraRotation.x, 0, 0);
    }

    void OnMovePressed()
    {
        // This gets (x,y) values from the Input System
        Vector2 moveValue = player.MoveAction.ReadValue<Vector2>();
        Move(moveValue.x, moveValue.y);
    }

    void OnSprintPressed()
    {
        if (player.SprintAction.IsPressed() && IsGrounded())
        {
            Sprint();
        }
    }

    void OnAttackPressed()
    {

    }

    void OnJumpClicked()
    {
        if (player.JumpAction.IsPressed() &&
            player.Rb.linearVelocity.y <= 0)
        {
            Jump();
        }
    }
}
