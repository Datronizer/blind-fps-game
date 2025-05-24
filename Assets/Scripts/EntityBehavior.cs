using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    Entity entity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entity.EntitySoundManager = GameObject.Find("EntitySoundManager")
            .GetComponent<EntitySoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravityToSelf();
    }

    public void ApplyGravityToSelf()
    {
        if (!IsGrounded())
        {
            // Apply gravity to the entity
            Vector3 gravity = new Vector3(0, -9.81f, 0);
            transform.Translate(gravity * Time.deltaTime);
        }
    }

    /// <summary>
    /// Check if the entity is on the ground
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out _, 1.0f);
    }
}
