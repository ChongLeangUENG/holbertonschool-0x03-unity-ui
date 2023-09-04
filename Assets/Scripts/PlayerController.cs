using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // Adjustable speed in the Inspector
    private int score = 0;
    public int health = 5;

    private void Start()
    {
        // Initialization code if needed
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");

            // Reset health and score
            health = 5;
            score = 0;

            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        // Get input values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        
        // Normalize the movement vector to avoid diagonal movement being faster
        movement.Normalize();

        // Move the player
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Increment score when player touches a Pickup object
            score++;
            Debug.Log("Score: " + score);

            // Disable or destroy the coin
            other.gameObject.SetActive(false); // Or Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            // Decrement health when player touches a Trap object
            health--;
            Debug.Log("Health: " + health);
        }
        else if (other.CompareTag("Goal"))
        {
            // Player has touched the goal
            Debug.Log("You win!");
        }
    }
}
