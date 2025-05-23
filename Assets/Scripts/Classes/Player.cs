using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    public new float moveSpeed = 4f;
    public new float sprintMultiplier = 1.5f;
    public new float timeToMaxSprint = 1.2f;
    public new float timeToStopSprint = 0.5f;

    // Input actions
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;
    InputAction sprintAction;

    GameObject playerCamera;

    public InputAction MoveAction { get => moveAction; set => moveAction = value; }
    public InputAction JumpAction { get => jumpAction; set => jumpAction = value; }
    public InputAction LookAction { get => lookAction; set => lookAction = value; }
    public InputAction SprintAction { get => sprintAction; set => sprintAction = value; }

    public GameObject PlayerCamera { get => playerCamera; set => playerCamera = value; }
}