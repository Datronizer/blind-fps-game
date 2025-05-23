using UnityEngine;
using UnityEngine.InputSystem;

public class Character
{
    public float moveSpeed = 3f;
    public float sprintMultiplier = 1.15f;

    public float timeToMaxSprint = 0.7f;
    public float timeToStopSprint = 0.3f;

    float currentSprintValue = 1f;
    float sprintTimer = 0f;

    float health = 100f;
    //Weapon weapon; // TODO: Make this class

    bool isDetected = false; // If the character is detected by the sound and reveals tier 1 information
    bool isIdentified = false; // If the character is identified and reveals tier 2 information


    public float Health { get => health; set => health = value; }
    public bool IsDetected { get => isDetected; set => isDetected = value; }
    public bool IsIdentified { get => isIdentified; set => isIdentified = value; }

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float SprintMultiplier { get => sprintMultiplier; set => sprintMultiplier = value; }
    public float TimeToMaxSprint { get => timeToMaxSprint; set => timeToMaxSprint = value; }
    public float TimeToStopSprint { get => timeToStopSprint; set => timeToStopSprint = value; }

    public float CurrentSprintValue { get => currentSprintValue; set => currentSprintValue = value; }
    public float SprintTimer { get => sprintTimer; set => sprintTimer = value; }


}
