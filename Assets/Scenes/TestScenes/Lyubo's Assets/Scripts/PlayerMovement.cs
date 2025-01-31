using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintMultiplier = 2f;
    public float jumpForce = 250f;
    public float mouseSensitivity = 100f;
    public AudioSource jumpSound;
    public AudioSource walkSound;
    public AudioSource runSound;

    private Rigidbody rb;
    private bool grounded;
    private float currentSpeed;
    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        cameraTransform.SetParent(transform);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * sprintMultiplier : speed;

        rb.AddForce(movement * currentSpeed);

        if (grounded && (moveHorizontal != 0 || moveVertical != 0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!runSound.isPlaying)
                    runSound.Play();
                walkSound.Stop();
            }
            else
            {
                if (!walkSound.isPlaying)
                    walkSound.Play();
                runSound.Stop();
            }
        }
        else
        {
            walkSound.Stop();
            runSound.Stop();
        }

        
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}