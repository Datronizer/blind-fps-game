using System;
using UnityEngine;

public class EntitySoundManager : MonoBehaviour
{
    // Imports
    GameObject characterModel;

    // Debug stuff
    public GameObject debugDetectionSphere;
    public GameObject debugProjectionSphere;

    // Adjustable variables
    public float detectionRange = 2f;
    public float projectionRange = 5f;

    public bool isDetected = false;  // If the character is detected by the sound and reveals tier 1 information
    public bool isIdentified = false;  // If the character is identified and reveals tier 2 information


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // DEBUG
        debugDetectionSphere.transform.localScale = new Vector3(detectionRange, detectionRange, detectionRange);
        debugProjectionSphere.transform.localScale = new Vector3(projectionRange, projectionRange, projectionRange);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProjectSound(string source)
    {
        Debug.Log("Sound projected from " + source);
        //debugDetectionSphere.transform.localScale = new Vector3(0, 0, 0);
    }
}
