using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hitForceMultiplier = 20f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 newVelocity = new Vector3(ballRb.velocity.x, hitForceMultiplier, ballRb.velocity.z);

            ballRb.velocity = newVelocity;

            StartCoroutine(DestroyBallAfterDelay(collision.gameObject));
        }
    }

    IEnumerator DestroyBallAfterDelay(GameObject ball)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(ball);
    }
}
