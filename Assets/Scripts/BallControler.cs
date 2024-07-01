using UnityEngine;

public class BallControler : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private float speed;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ring"))
        {
                ballRb.AddForce(Vector3.up * speed,ForceMode.Impulse);
        }

        else if (collision.gameObject.CompareTag("DangerRing"))
        {
            Debug.Log("Game Over");
        }

        else if (collision.gameObject.CompareTag("WinRing"))
        {
            Debug.Log("Level Complete");
        }
    }
}

