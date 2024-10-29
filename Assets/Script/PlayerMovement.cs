using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public Vector2 minBound;     // Minimum X and Z positions
    public Vector2 maxBound;     // Maximum X and Z positions

    private Rigidbody rb;        // Reference to Rigidbody component

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody if you're using physics
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Log input for debugging
        Debug.Log("Horizontal Input: " + horizontalInput);
        Debug.Log("Vertical Input: " + verticalInput);

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);

        // Get the current position of the player
        Vector3 newPosition = transform.position;

        // Clamp the player's position within the min/max boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minBound.x, maxBound.x);
        newPosition.z = Mathf.Clamp(newPosition.z, minBound.y, maxBound.y);

        // Update the player's position
        transform.position = newPosition;
    }
}
