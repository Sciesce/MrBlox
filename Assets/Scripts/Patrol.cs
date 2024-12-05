using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    // Declaring needed variables
    private Vector2 pointA; // Starting point
    private Vector2 pointB; // End point 
    public GameObject targetObject; // Exposing move to target for simple back and forth movement
    public float lerpDuration = 2f; // Time to complete movement
    private float elapsedTime; // Tracking the time
    private bool movingToTarget = true; // Whether it is moving to a target
    private Vector2 originalPointA; // Store the original pointA for looping

   
    // Start is called before the first frame update
    void Start()
    {
        // Initialize pointA to the current position of the enemy
        pointA = transform.position;

        // Store the original pointA
        originalPointA = pointA;

        // If a target object is assigned, set pointB to its position
        if (targetObject != null)
        {
            pointB = targetObject.transform.position;
        }
        else
        {
            pointB = pointA; // Default to the start point if no target object is provided
        }

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / lerpDuration); // Normalize time (0 to 1)

        // Move the object between pointA and pointB using Lerp
        transform.position = Vector2.Lerp(pointA, pointB, t);

        // If the lerp is complete (t >= 1), toggle direction
        if (t >= 1f)
        {
            // Reset elapsed time for the next lerp cycle
            elapsedTime = 0f;

            // Toggle between moving towards pointA or pointB
            if (movingToTarget)
            {
                movingToTarget = false;
                pointA = pointB; // Set pointA to the current pointB for the return
                pointB = originalPointA; // Set pointB to the original starting point
            }
            else
            {
                movingToTarget = true;
                pointA = originalPointA; // Reset pointA back to the original start position
                pointB = targetObject.transform.position; // Update pointB to the target position
            }
        }
    }
}
