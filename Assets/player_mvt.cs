using UnityEngine;
using UnityEngine.InputSystem;

public class player_mvt : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float mouseSensitivity = 2f;

    private Vector3 moveDirection;
    private float rotationY;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;

        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

//jump control

    [SerializeField]
    InputAction jump;

    [SerializeField]
    float jumpForce = 5f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        jump.Enable();
    }

    private void FixedUpdate()
    {
       if (jump.IsPressed())
        {
             if (gameObject.transform.position.y < 1.2f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
    }
        }

}
