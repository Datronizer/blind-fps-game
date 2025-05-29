using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    public Player()
    {
        // Set base class values for this Player instance
        MoveSpeed = 3f;
        SprintMultiplier = 1.3f;
        TimeToMaxSprint = 0.8f;
        TimeToStopSprint = 0.2f;
    }


    // Input actions
    public InputAction MoveAction { get ; set ; }
    public InputAction JumpAction { get ; set ; }
    public InputAction LookAction { get; set; }
    public InputAction SprintAction { get; set; }

    public GameObject PlayerCameraGameObject { get; set; }
}