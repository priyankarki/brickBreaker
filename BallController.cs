using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;
    private bool started = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.linearVelocity = new Vector3(0, 0, 10); // initial direction
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // prevents tunneling
    }

    void Update()
    {
        if (!started && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(1f, 1f, 0f).normalized * speed;
            started = true;
        }

        // Keeping z axis locked
        Vector3 p = transform.position;
        p.z = 0f;
        transform.position = p;
    }

    void OnCollisionEnter(Collision collision)
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;

        if (collision.gameObject.CompareTag("Brick"))
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Paddle"))
        {
            float xDir = rb.linearVelocity.x;
            float yDir = Random.Range(0.5f, 1f); // random upward
            rb.linearVelocity = new Vector3(xDir, yDir, 0).normalized * speed;
        }
    }
}
