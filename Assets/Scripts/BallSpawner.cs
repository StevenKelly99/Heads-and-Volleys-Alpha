using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnInterval = 2f;
    public float ballSpeed = 5f;

    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (GameManager.Instance.IsGameActive())
        {
            yield return new WaitForSeconds(Random.Range(0, spawnInterval));

            GameObject newBall = Instantiate(ballPrefab, new Vector3(0f, 15f, 0f), Quaternion.identity);
            Rigidbody rb = newBall.GetComponent<Rigidbody>();

            rb.velocity = new Vector3(Random.Range(-1f, 1f), -1f, 0f).normalized * ballSpeed;
        }
    }
}
