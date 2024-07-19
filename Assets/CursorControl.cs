using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the cursor movement speed

    void Update()
    {
        // Get input from arrow keys or WASD for cursor movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Apply movement to the cursor position
        transform.Translate(movement);
    }
}
