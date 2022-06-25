using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;
    //private InputManager inputManager;
    private Rigidbody2D rb;
    private Vector2 direction;
    [SerializeField] private float speed;
    private bool isTouching;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new Controls();
        isTouching = false;
    }

    // Called every time the object is enabled
    private void OnEnable()
    {
        controls.Enable();
    }

    // Called every time the object is disabled
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Player.TouchPress.started += ctx => StartTouch(ctx);
        controls.Player.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        isTouching = true;
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        isTouching = false;
    }

    private void Update()
    {
        if (isTouching)
        {
            Vector2 touchPositionScreen = controls.Player.Move.ReadValue<Vector2>();
            Vector3 touchPositionWorld = Camera.main.ScreenToWorldPoint(touchPositionScreen);
            touchPositionWorld.z = 0;

            direction = (touchPositionWorld - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * speed;

            if (!isTouching)
                rb.velocity = Vector2.zero;
        }
        else
            rb.velocity = Vector2.zero;
    }

}
