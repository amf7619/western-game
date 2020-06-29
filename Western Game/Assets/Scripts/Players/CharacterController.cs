using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool movementEnabled = true;
    public bool jumpEnabled = true;

    private float horizontalMove;
    private float verticalMove;
    private float jumpMove;

    private Vector3 movement;

    [SerializeField]
    private float movementSpeed = 5;
    [SerializeField]
    private float jumpHeight = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Vector3.Lerp(movement, Vector3.zero, 0.5f);

        CalculateMove();
        CalculateJump();
        MovePlayer();
    }

    void CalculateMove()
    {
        if (!movementEnabled)
        {
            return;
        }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void CalculateJump()
    {
        if(!jumpEnabled)
        {
            return;
        }

        jumpMove = Input.GetAxisRaw("Jump");
    }

    void MovePlayer()
    {
        movement = new Vector3(horizontalMove, 0, verticalMove).normalized * movementSpeed;
        movement.y += jumpMove * jumpHeight;

        transform.position += movement * Time.deltaTime;
    }
}
