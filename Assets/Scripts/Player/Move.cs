using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    private CharacterController controller;

    [Header("Jump")]
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    [Header("Crouch")]
    public float crouchHeight = 0f;
    public float crouchRadius = 0.25f;
    private float normalHeight;
    private float normalRadius;
    private Vector3 normalCenter;
    private Vector3 crouchCenter;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // Save original height and center for crouching
        normalHeight = controller.height;
        normalCenter = controller.center;
        normalRadius = controller.radius;

        // Calculate the center position for crouching based on the normal center and the difference in height
        crouchCenter = new Vector3(normalCenter.x, normalCenter.y / 2f, normalCenter.z);
    }

    private void Update()
    {
        HandleMovementAndJump();
        HandleCrouch();
    }

    private void HandleMovementAndJump()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (InputManager.Instance.JumpPressed() && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector2 inputMovement = InputManager.Instance.GetMovement();
        Vector3 move = new Vector3(inputMovement.x, 0f, 0f) * speed;

        Vector3 finalMovement = move + velocity;

        controller.Move(finalMovement * Time.deltaTime);
    }

    private void HandleCrouch()
    {
        if (InputManager.Instance.IsCrouching())
        {
            controller.height = crouchHeight;
            controller.center = crouchCenter;
            controller.radius = crouchRadius;
        }
        else
        {
            controller.height = normalHeight;
            controller.center = normalCenter;
            controller.radius = normalRadius;
        }
    }
}