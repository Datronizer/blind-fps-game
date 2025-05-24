using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    public Player()
    {
        // Set base class values for this Player instance
        MoveSpeed = 4f;
        SprintMultiplier = 5f;
        TimeToMaxSprint = 1.2f;
        TimeToStopSprint = 0.5f;
    }


    // Input actions
    public InputAction MoveAction { get ; set ; }
    public InputAction JumpAction { get ; set ; }
    public InputAction LookAction { get; set; }
    public InputAction SprintAction { get; set; }

    public GameObject PlayerCameraGameObject { get; set; }
}