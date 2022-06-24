using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerBody;
    private Vector3 direction;
    private Vector3 touchPosition;

    private float mapWidth = 6f;


    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        Vector2 newPosition = playerBody.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        playerBody.MovePosition(newPosition);
    }
}
