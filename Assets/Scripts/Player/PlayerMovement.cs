using UnityEngine;

// No longer used
public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Camera camMain;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        camMain = Camera.main;
    }

    private void OnEnable()
    {
        // Susbscribe to event 
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        // Unsusbscribe to event 
        inputManager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        //Convert from screen to world coordinates then keep z constant so we don't zoom
        Vector3 screenPositionV3 = new Vector3(
            screenPosition.x,
            screenPosition.y,
            0 // camMain.nearClipPlane
        );
        Vector3 worldCordinates = camMain.ScreenToWorldPoint(screenPositionV3);
        worldCordinates.z = 0;

        transform.position = worldCordinates;
    }
}
