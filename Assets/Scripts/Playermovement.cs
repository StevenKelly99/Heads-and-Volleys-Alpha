using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f; 
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? sprintSpeed : moveSpeed;

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        transform.Translate(movement * currentSpeed * Time.deltaTime);

        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float minX = mainCamera.transform.position.x - cameraHalfWidth;
        float maxX = mainCamera.transform.position.x + cameraHalfWidth;

        float playerX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
    }
}
