using UnityEngine;

public class Entity
{
    public Entity()
    {
        Health = 100f;

        MoveSpeed = 3f;
        SprintMultiplier = 1.15f;
        TimeToMaxSprint = 0.7f;
        TimeToStopSprint = 0.3f;

        CurrentSprintValue = 1f;
        SprintTimer = 0f;

        PrimaryWeapon = new Weapon();
        SecondaryWeapon = new Weapon();
    }


    public float Health { get; set; }


    public float MoveSpeed { get; set; }
    public float SprintMultiplier { get; set; }
    public float TimeToMaxSprint { get; set; }
    public float TimeToStopSprint { get; set; }


    public float CurrentSprintValue { get; set; }
    public float SprintTimer { get; set; }


    public Weapon PrimaryWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }


    public EntitySoundManager EntitySoundManager { get; set; }
}
