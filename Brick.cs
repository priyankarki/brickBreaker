using UnityEngine;

public class Brick : MonoBehaviour
{
    private BrickManager manager;

    public void Init(BrickManager mgr)
    {
        manager = mgr;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (manager != null)
                manager.BrickDestroyed();

            Destroy(gameObject);
        }
    }
}
