using UnityEngine;

public class Entity
{
    public Entity()
    {
        Health = 100f;

        MoveSpeed = 2f;

        SprintMultiplier = 1.1f;
        TimeToMaxSprint = 0.7f;
        TimeToStopSprint = 0.3f;

        JumpForce = 6.5f;

        CurrentSprintValue = 1f;
        SprintTimer = 0f;

        TurnTime = 0.1f;

        PrimaryWeapon = new Weapon();
        SecondaryWeapon = new Weapon();
    }


    public float Health { get; set; }


    public float MoveSpeed { get; set; }
    public float SprintMultiplier { get; set; }
    public float TimeToMaxSprint { get; set; }
    public float TimeToStopSprint { get; set; }


    public float JumpForce { get; set; }


    public float CurrentSprintValue { get; set; }
    public float SprintTimer { get; set; }


    public float TurnTime { get; set; }


    public Weapon PrimaryWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }


    public EntitySoundManager EntitySoundManager { get; set; }


    public Rigidbody Rb { get; set; }
}
