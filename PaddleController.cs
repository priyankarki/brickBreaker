using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 20f;
    public float xAxisLimit = 6f;

    void Update()
    {
        // Horizontal input keys
        float boost = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        float move = Input.GetAxis("Horizontal") * speed * boost * Time.deltaTime;


        // Move only in x axis
        transform.Translate(move, 0, 0, Space.World);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xAxisLimit, xAxisLimit);

        // Locking Z axis
        pos.z = 0f;

        transform.position = pos;
    }
}
