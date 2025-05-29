using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    protected Entity entity = new Entity();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entity.EntitySoundManager = GameObject.Find("EntitySoundManager")
            .GetComponent<EntitySoundManager>();
        entity.Rb = GetComponent<Rigidbody>();

        // Set the Rigidbody properties
        entity.Rb.maxLinearVelocity = entity.MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ClampRestingVelocity();
    }

    protected virtual void Move(float x, float z)
    {
        // Create a 3D vector for movement based on input and use 
        entity.Rb.AddRelativeForce(
            entity.CurrentSprintValue *
            entity.MoveSpeed *
            new Vector3(x, 0, z)
        );
        entity.Rb.angularVelocity = Vector3.zero; // Prevent rotation sliding

        //SoundBehavior.ProjectSound(name);
    }
    protected virtual void Move(Vector3 moveValue3d)
    {
        Vector3 movement = entity.CurrentSprintValue * entity.MoveSpeed * moveValue3d;

        entity.Rb.AddRelativeForce(movement, ForceMode.VelocityChange);
        entity.Rb.linearVelocity = Vector3.ClampMagnitude(movement, entity.MoveSpeed);
        entity.Rb.angularVelocity = Vector3.zero; // Prevent rotation sliding

        //SoundBehavior.ProjectSound(name);
    }

    protected virtual void Sprint()
    {
        entity.Rb.linearVelocity *= entity.SprintMultiplier;
    }


    protected virtual void Jump()
    {
        // Apply an impulse force upwards for the jump
        if (IsGrounded())
        {
            entity.Rb.linearVelocity = new Vector3(entity.Rb.linearVelocity.x, entity.JumpForce, entity.Rb.linearVelocity.z);
        }
    }

    /// <summary>
    /// Check if the entity is on the ground
    /// </summary>
    /// <returns></returns>
    protected bool IsGrounded()
    {
        float groundedDistance = 1.1f; // Distance to check for ground

        // Check if the entity is on the ground using a raycast
        return Physics.Raycast(transform.position, Vector3.down, groundedDistance);
    }

    protected void ClampRestingVelocity()
    {
        Vector3 horizontalVelocity = GetHorizontalVelocityVector();
        // If ground speed is less than 0.1, stop movement
        if (horizontalVelocity.magnitude < 0.1f)
        {
            entity.Rb.linearVelocity = new Vector3(0f, entity.Rb.linearVelocity.y, 0f);
        }
    }

    private Vector3 GetHorizontalVelocityVector()
    {
        Vector3 horizontalVelocity = entity.Rb.linearVelocity;
        horizontalVelocity.y = 0f;
        return horizontalVelocity;
    }
}
