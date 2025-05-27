using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    protected Entity entity = new Entity();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entity.EntitySoundManager = GameObject.Find("EntitySoundManager")
            .GetComponent<EntitySoundManager>();
        entity.Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Move(Vector3 normalizedMoveDirection)
    {
        entity.Rigidbody.linearVelocity = entity.CurrentSprintValue * entity.MoveSpeed * Time.deltaTime * normalizedMoveDirection;
        //SoundBehavior.ProjectSound(name);
    }

    protected virtual void Sprint() { }


    protected virtual void Jump()
    {
        //if (IsGrounded())
        //{
        //    // Jump
        //    Vector3 jumpForce = new Vector3(0, 5f, 0);
        //    transform.Translate(jumpForce * Time.deltaTime);
        //}
        // Jump
        Vector3 jumpForce = new Vector3(0, 9.81f + 5f, 0);
        transform.Translate(jumpForce * Time.deltaTime);
    }

    /// <summary>
    /// Check if the entity is on the ground
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        // Check if the entity is on the ground using a raycast
        return Physics.Raycast(transform.position, Vector3.down, out _, 1f);
    }
}
