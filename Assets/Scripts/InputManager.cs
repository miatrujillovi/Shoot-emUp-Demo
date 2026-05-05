using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    /*USE THE GET FUNCTIONS TO GET THE ACCORDING ACTION
     * GetMovement() -> Gives you a 2D Vector
     * GetLook() -> Gives you a 2D Vector
     * JumpPressed() -> Gives a bool
     * IsCrouching() -> Gives a bool
     * ShootPressed() -> Gives a bool
    */

    public static InputManager Instance;

    private PlayerControls playerInputs;

    //MOVEMENT
    private InputAction movement;
    private Vector2 moveInput;
    public Vector2 GetMovement() => moveInput;

    //LOOK
    private InputAction look;
    private Vector2 lookInput;
    public Vector2 GetLook() => lookInput;

    //JUMP
    private InputAction jump;
    public bool JumpPressed() => jump.triggered;

    //CROUCH
    private InputAction crouch;
    private bool isCrouching;
    public bool IsCrouching() => isCrouching;

    //SHOOT
    private InputAction shoot;
    public bool ShootPressed() => shoot.triggered;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Access the Player Action Map
        playerInputs = new PlayerControls();
        var gameplayActionMap = playerInputs.Player;

        //MOVEMENT
        movement = gameplayActionMap.Move;

        //LOOK
        look = gameplayActionMap.Look;

        //JUMP
        jump = gameplayActionMap.Jump;

        //CROUCH
        crouch = gameplayActionMap.Crouch;

        //SHOOT
        shoot = gameplayActionMap.Attack;
    }

    private void OnEnable()
    {
        movement.Enable();
        look.Enable();
        jump.Enable();
        crouch.Enable();
        shoot.Enable();

        //MOVEMENT
        movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        movement.canceled += ctx => moveInput = Vector2.zero;

        // LOOK
        look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        look.canceled += ctx => lookInput = Vector2.zero;

        // CROUCH (hold)
        crouch.performed += ctx => isCrouching = true;
        crouch.canceled += ctx => isCrouching = false;
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        jump.Disable();
        crouch.Disable();
        shoot.Disable();

        //MOVEMENT
        movement.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        movement.canceled -= ctx => moveInput = Vector2.zero;

        // LOOK
        look.performed -= ctx => lookInput = ctx.ReadValue<Vector2>();
        look.canceled -= ctx => lookInput = Vector2.zero;

        // CROUCH (hold)
        crouch.performed -= ctx => isCrouching = true;
        crouch.canceled -= ctx => isCrouching = false;
    }
}
