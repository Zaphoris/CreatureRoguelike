using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovenetBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8;
    [SerializeField] float jumpForce = 25;

    Rigidbody2D myRidibody;
    BoxCollider2D myBoxCollider;

    Vector2 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        myRidibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /// <summary>
    /// This moves the player to move left or right
    /// </summary>
    void Move()
    {
        //Increase the x value by the move speed and the delta time...
        Vector2 movement = new Vector2(inputVector.x * moveSpeed * Time.deltaTime, 0);
        //Apply the x value to the transform
        transform.Translate(movement);
    }
    /// <summary>
    /// This moves the player up
    /// </summary>
    void Jump()
    {
        //If the collider touches the ground...
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Allow the player to jump.
            myRidibody.velocity = new Vector2(myRidibody.velocity.x, jumpForce);
        }
    }
    /// <summary>
    /// Allow for movement on the y and x axis
    /// </summary>
    /// <param InputValue="value">This is the key board input like wasd</param>
    void OnMove(InputValue value)
    {
        //Set the input vecator to the input values vector 2
        inputVector = value.Get<Vector2>();
    }
    /// <summary>
    /// This allows the player to jump
    /// </summary>
    /// <param InputValue="value">This is the arrow keys , space bar, or the key W</param>
    void OnJump(InputValue value) 
    {
        //If the key is pressed...
        if(value.isPressed) 
        {
            //Call Jump.
            Jump();
        }
    }
}
