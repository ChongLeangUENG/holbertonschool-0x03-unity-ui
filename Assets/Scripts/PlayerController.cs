using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed; // Adjustable speed in the Inspector
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public GameObject winLoseText;
    public GameObject winLoseBG;

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
            // Debug.Log("Score: " + score);
            SetScoreText();
            // Disable or destroy the coin
            other.gameObject.SetActive(false); // Or Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            // Decrement health when player touches a Trap object
            health--;
            SetHealthText();
        }
        else if (other.CompareTag("Goal"))
        {
            winLoseText.GetComponent<Text>().text = "You Win!";
            winLoseText.GetComponent<Text>().color = Color.black;
            winLoseBG.GetComponent<Image>().color = Color.green;
            winLoseBG.SetActive(true);
        }
    }
    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
