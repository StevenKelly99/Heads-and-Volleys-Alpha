using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int scoreValue = 5;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRb = GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.Reflect(ballRb.velocity, collision.contacts[0].normal);

            if (GameManager.Instance.IsGameActive())
            {
                GameManager.Instance.AddScore(scoreValue);
            }

            StartCoroutine(DestroyBallAfterDelay());
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.Instance.IsGameActive() && GameManager.Instance.GetTimer() > 0f)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                GameManager.Instance.GameOver();
            }

            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBallAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
