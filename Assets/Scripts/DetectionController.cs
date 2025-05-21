using System;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    void Start()
    {
    }

    // Update is called once per frame  
    void Update()
    {
        // Fix for CS0029: Use GetComponent<Collision>() to retrieve a Collision component  
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Add your collision handling logic here  
        // For example, you can check if the collided object has a specific tag  
    }
}
