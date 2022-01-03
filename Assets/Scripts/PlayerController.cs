/*
 * Haochen Liu
 * 260917834
 * COMP521 A1
 */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // character controller of player
    private CharacterController controller;
    
    // speed for move & jump, can be defined in editor
    public float moveSpeed;
    public float jumpSpeed;

    // value of horiziontal move, vertical move and direction
    private float horizontalMove;
    private float verticalMove;
    private Vector3 dir;
 
    // define gravity 
    public float gravity;
    private Vector3 velocity;
    
    // for ground check 
    public bool groundCheck;
    public Transform checker;
    public float radius;
    public LayerMask ground;
    

    void Start()
    {
        this.controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // check whether player is "on the ground"
        groundCheck = Physics.CheckSphere(this.checker.position, this.radius, this.ground);

        // when hit/on the group, set the velocity to a certain value
        // otherwise it will always increase(in negative direction)
        if (groundCheck && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        this.horizontalMove = Input.GetAxis("Horizontal") * this.moveSpeed;
        this.verticalMove = Input.GetAxis("Vertical") * this.moveSpeed;
        // save the direction of move
        this.dir = transform.forward * this.verticalMove + transform.right * this.horizontalMove;
        // move at the designated direction and distance
        this.controller.Move(this.dir * Time.deltaTime);

        // player can only jump on the ground
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            velocity.y = this.jumpSpeed;
        }

        // v = gt, h = 1/2gt^2 - Newton
        velocity.y -= gravity * Time.deltaTime;
        this.controller.Move(0.5f*velocity * Time.deltaTime);
    }
}