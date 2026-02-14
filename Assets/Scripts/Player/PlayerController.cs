using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    [Header("Movement")]
    [SerializeField] float speed = 5f;
    [SerializeField] float runningSpeed = 10f;
    [SerializeField] float angularSpeed = 180f;

    [Header("Jump")]
    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference shoot;
    [SerializeField] InputActionReference run;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        move.action.Enable();
        jump.action.Enable();
        shoot.action.Enable();
        run.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        jump.action.started += OnJump;

        run.action.started += OnRun;
        run.action.canceled += OnRun;
    }
    
    float actualVelocity;
    private bool isGrounded;
    void Update()
    {
        isGrounded = characterController.isGrounded;

        actualVelocity = isRunning ? runningSpeed : speed;
            
        Vector3 moveToApply = new Vector3(0f, 0f, rawMove.y) * actualVelocity * Time.deltaTime ;
        moveToApply = transform.TransformDirection(moveToApply); 

        characterController.Move(moveToApply);

        float rotation = rawMove.x * angularSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);

        // Jump
        if (mustJump && isGrounded)
        {
            velocityJump.y = Mathf.Sqrt(2f * Mathf.Abs(-Physics.gravity.y) * jumpHeight);
            mustJump = false;
        }

        // Aplicar gravedad
        velocityJump.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocityJump * Time.deltaTime);

    }

    
    Vector2 rawMove = Vector2.zero;
    private void OnMove(InputAction.CallbackContext context)
    {
        // Podemos obtener el nombre del device
        // Debug.Log(context.control.device);

        rawMove = context.ReadValue<Vector2>();
    }

    bool mustJump = false;
    private Vector3 velocityJump;
    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded){
            mustJump = context.ReadValueAsButton();
        }
    }

    bool isRunning = false;
    private void OnRun(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
    }


    private void OnDisable()
    {
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        jump.action.started -= OnJump;

        run.action.started -= OnRun;
        run.action.canceled -= OnRun;

        move.action.Disable();
        jump.action.Disable();
        shoot.action.Disable();
        run.action.Disable();
    }
}
