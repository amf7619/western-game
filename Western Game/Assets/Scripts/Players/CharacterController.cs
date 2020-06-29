using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //booleans to control player inputs. Can be turned off for cutscenes or special sections of the level
    public bool movementEnabled = true;
    public bool jumpEnabled = true;

    //floats to read input from player
    private float horizontalMove;
    private float verticalMove;
    private float jumpMove;

    //Vector for calculating movement direction and force
    private Vector3 movement;

    //variables to control the math used to calculate the speed and jump height
    [SerializeField]
    private readonly float baseMovementSpeed = 5;
    private float movementSpeed;
    [SerializeField]
    private readonly float sprintModifier = 1.5f;
    [SerializeField]
    private readonly float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = baseMovementSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Allow some sliding in movement by LERPing to 0
        movement = Vector3.Lerp(movement, Vector3.zero, 0.5f);

        CalculateMove();
        CalculateJump();
        MovePlayer();
    }

    //Calculates the movement around the stage
    void CalculateMove()
    {
        movementSpeed = baseMovementSpeed;

        if (!movementEnabled)
        {
            return;
        }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

    }

    //Calculates the jumping of the player
    void CalculateJump()
    {
        if(!jumpEnabled)
        {
            return;
        }

        jumpMove = Input.GetAxisRaw("Jump");
    }

    //Uses the variables to move the transform position
    void MovePlayer()
    {
        movement = new Vector3(horizontalMove, 0, verticalMove).normalized * movementSpeed;
        movement.y += jumpMove * jumpForce;

        transform.position += movement * Time.deltaTime;
    }
}
