using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerBody;
    private Vector3 direction;
    private Vector3 touchPosition;


    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            touchPosition.z = 0;

            direction = (touchPosition - transform.position);

            playerBody.velocity = new Vector2(direction.x, direction.y) * speed;

            if (t.phase == TouchPhase.Ended)
                playerBody.velocity = Vector2.zero;

        }
    }
}
