using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class PlayerControllerOld : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float runningSpeed = 10f;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference shoot;
    [SerializeField] InputActionReference run;

    Vector2 rawMove = Vector2.zero;


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

            // Para coger el Device del jugador
            // Guardariamos el device.name por ejemplo
            // Al leer los valores pondriamos un if para ver si es ese device
            // InputSystem.onAnyButtonPress.CallOnce(ctrl => Debug.Log($"Button {ctrl} was pressed on Device {ctrl.device}"));
        }

        float actualVelocity;
        private void Update()
        {
            if (mustJump)
            {
                mustJump = false;
            }

            actualVelocity = isRunning ? runningSpeed : speed;
            
            Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * actualVelocity * Time.deltaTime ;
            transform.Translate(moveToApply);
        } 

        private void OnMove(InputAction.CallbackContext context)
        {
            // Podemos obtener el nombre del device
            // Debug.Log(context.control.device);

            rawMove = context.ReadValue<Vector2>();
        }

        bool mustJump = false;
        private void OnJump(InputAction.CallbackContext context)
        {
            mustJump = context.ReadValueAsButton();
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

    
    /*
    // Si usamos el componente Player Input

    void OnMove(InputValue value)
    {
        rawMove = value.Get<Vector2>();
        Debug.Log("MUEVEE");
    }

    bool mustJump = false;
    void OnJump()
    {
        mustJump = true;
    }
    */
}
