using UnityEngine;
using UnityEngine.InputSystem;

// ensures this script is run before others
[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    // Delegate: Let other scripts handle the functionality.
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;


    private TouchControls touchControls;

    // Awake method used for initilization (runs before game starts)
    private void Awake()
    {
        touchControls = new TouchControls();
    }

    // Start runs when script is loaded in memory 
    private void Start()
    {
        // Callback function gets passed the context
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    // Called every time the object is enabled
    private void OnEnable()
    {
        touchControls.Enable();
    }

    // Called every time the object is disabled
    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void StartTouch(InputAction.CallbackContext contetxt)
    {
        // Only emmit event if other scripts are listening
        if (OnStartTouch != null)
        {
            OnStartTouch(
                touchControls.Touch.TouchPosition.ReadValue<Vector2>(),
                (float)contetxt.startTime
            );
        }

    }

    private void EndTouch(InputAction.CallbackContext contetxt)
    {
        // Only emmit event if other scripts are listening
        if (OnEndTouch != null)
        {
            OnEndTouch(
                touchControls.Touch.TouchPosition.ReadValue<Vector2>(),
                (float)contetxt.time
            );
        }
    }
}
