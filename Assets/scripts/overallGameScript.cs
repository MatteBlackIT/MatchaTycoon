using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Task management
    public Transform currentTaskLocation; // The task the PC is working on
    public float moveSpeed = 3f; // Movement speed of the PC
    private bool isBusy = false; // Tracks if the PC is working on a task

    void Update()
    {
        // Move towards the current task location if assigned
        if (currentTaskLocation != null && !isBusy)
        {
            MoveToTask();
        }
    }

    // Method to move the PC to the task location
    void MoveToTask()
    {
        Vector3 direction = (currentTaskLocation.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Check if the PC has reached the task location
        if (Vector3.Distance(transform.position, currentTaskLocation.position) < 0.1f)
        {
            StartTask();
        }
    }

    // Method to simulate starting a task
    void StartTask()
    {
        isBusy = true;
        StartCoroutine(TaskCompletionRoutine());
    }

    // Simulate task completion with a delay
    IEnumerator TaskCompletionRoutine()
    {
        Debug.Log("PC: Starting task...");
        yield return new WaitForSeconds(3f); // Simulate task time
        Debug.Log("PC: Task completed!");
        isBusy = false;
        currentTaskLocation = null; // Clear task
    }
}