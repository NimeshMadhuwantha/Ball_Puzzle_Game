using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For restarting the game

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float moveForce = 25f;
    public float friction = 0.2f;

    public Text messageText; // To display messages like "Ball is collected", "You Win", etc.
    public Text timerText; // To display the countdown timer

    private float countdownTime = 30f; // Countdown timer in seconds
    private bool gameWon = false; // To track if the player has won

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        messageText.text = ""; // Clear message text at the start
        UpdateTimerText(); // Initialize the timer text
    }

    void FixedUpdate()
    {
        if (gameWon) return; // Stop player movement after winning

        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Apply force based on input
        Vector2 inputForce = new Vector2(horizontalInput, verticalInput) * moveForce;
        rBody.AddForce(inputForce);

        // Apply friction by reducing velocity
        rBody.linearVelocity *= friction;
    }

    void Update()
    {
        if (gameWon) return; // Stop updating the timer if the game is won

        // Update the countdown timer
        countdownTime -= Time.deltaTime;
        UpdateTimerText();

        // Check if time is up
        if (countdownTime <= 0)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("PickUp"))
        {
            Destroy(target.gameObject);
            messageText.text = "Ball is collected!";
        }
        else if (target.gameObject.CompareTag("PickUpGift"))
        {
            Destroy(target.gameObject);
            messageText.text = "You Win! Congratulations!";
            gameWon = true; // Stop further updates
        }
    }

    void UpdateTimerText()
    {
        // Update the timer text
        timerText.text = "Time Left: " + Mathf.Max(0, Mathf.FloorToInt(countdownTime)) + "s";
    }

    void GameOver()
    {
        // Display game-over message
        messageText.text = "Game Over! Try Again!";
        Invoke("RestartGame", 3f); // Restart the game after 3 seconds
    }

    void RestartGame()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
