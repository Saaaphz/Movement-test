using UnityEngine;
using UnityEngine.InputSystem;

public class player_mvt : MonoBehaviour
{
    
    [Header("References")]
    public Rigidbody rb;

    [SerializeField]
    public float moveSpeed = 5f;

    [SerializeField]
    Vector3 _moveInput;

    [SerializeField]
    private float mouseSensitivity = 2f;
    private Vector3 moveDirection;
    private float rotationY;

    [Header("Collision Info")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance;
    private bool isGrounded;



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

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;

        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

//jump control

     private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

}

  