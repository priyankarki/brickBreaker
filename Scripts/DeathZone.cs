using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public GameObject gameOverUI;
    public PaddleController paddle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Show Game Over UI
            if (gameOverUI != null)
                gameOverUI.SetActive(true);

            // Stop paddle movement
            if (paddle != null)
                paddle.enabled = false;

            // Ball falls through screen
            BallController ballScript = other.GetComponent<BallController>();
            if (ballScript != null)
                ballScript.enabled = false;

            // Ensure gravity pulls it down
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;   // enable gravity
                rb.linearVelocity = Vector3.down * 5f;
            }
        }
    }
}