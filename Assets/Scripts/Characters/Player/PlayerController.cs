using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public enum Playerstate
    {
        idle,
        walk,
        attack,
        stagger
    }

    public Playerstate currentState;
    [SerializeField] private float staggerResetTime;


    [Header("Movement")]
    public Rigidbody2D playerRb;
    [SerializeField] private float speed;
    private Vector2 moveInput;
    private bool isMoving;
    public bool facingLeft;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    public bool isGrounded = true; //set and updated by GroundcheckScript
    [SerializeField] private int possibleJumps;
    [SerializeField]private int actualJumps;
    private bool isJumpPossible;
    private bool canJumpGamepadHelper = true; //needed bool to not jump once per frame with the input system


    [Header("Animation")]
    private Animator playerAnim;
    public bool isHugingWall; //set and updated by WallCheker
    public bool gameIsPaused;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetFloat(AnimationStaticStrings.moveY, playerRb.velocity.y);
        if (currentState==Playerstate.stagger)
        {
            StartCoroutine(StaggerResetCo());
        }
        if (!gameIsPaused)
        {
        IsJumpPossible();
        SetAnimation();
        IsMovingCheck();
        }
    }


    private void FixedUpdate()
    {
        if (currentState==Playerstate.attack)
        {
            playerRb.velocity = new(0, playerRb.velocity.y);
        }
        else if (currentState==Playerstate.stagger)
        {

        }
        else
        {
        playerRb.velocity = new(moveInput.x * speed, playerRb.velocity.y);

        }
    }


    public void Move(InputAction.CallbackContext context) //handle Input System event to move
    {
        if (currentState!=Playerstate.stagger)
        {
            moveInput.x = context.ReadValue<Vector2>().x;

        }
        else
        {
            moveInput.x = 0;
        }
    }

    private void IsMovingCheck()
    {
        if (moveInput.x != 0
            && !isHugingWall)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }


    //handle Input System event to jump
    public void OnJump(InputAction.CallbackContext context) 
    {
        if (currentState!=Playerstate.stagger)
        {
            if (context.performed
                && currentState != Playerstate.attack
                && isJumpPossible
                && canJumpGamepadHelper)
            {
                canJumpGamepadHelper = false;
                StartCoroutine(JumpGamepadReseter());
                actualJumps--;
                playerRb.velocity = new(moveInput.x, jumpForce);
            }
        }
    }

    //needed to reset the Input System event, otherwise gamepad is jumping once per frame
    private IEnumerator JumpGamepadReseter() 
    {
        yield return null;
        canJumpGamepadHelper = true;
    }

    //Calculate jumps... + full jumps after "falling" of edge
    private void IsJumpPossible()
    {
        if (isGrounded
            && Mathf.Round(playerRb.velocity.y)<=0)
        {
            actualJumps = possibleJumps;
        }

        if (actualJumps<=0)
        {
            isJumpPossible = false;
        }
        else
        {
            isJumpPossible = true;
        }
        
    }

    private void SetAnimation() //Set the vars for the Animations
    {
        if (currentState==Playerstate.stagger)
        {
            playerAnim.SetBool(AnimationStaticStrings.isMoving, false);
        }
        else
        {
            if (currentState!=Playerstate.attack)
            {
                FacingDirection();
                playerAnim.SetBool(AnimationStaticStrings.isMoving,isMoving);
            }
        }
            playerAnim.SetBool(AnimationStaticStrings.isGrounded, isGrounded);
    }

    private void FacingDirection() //checking for direction and flip player if necessary
    {
        if (moveInput.x<0)
        {
            facingLeft = true;
        }
        else if (moveInput.x>0)
        {
            facingLeft = false;
        }
        if (facingLeft) //flip to the left
        {
            transform.localScale = new(-1,1,1);
        }
        else //standart to the right
        {
            transform.localScale = new(1, 1, 1);
        }
    }

    private IEnumerator StaggerResetCo()
    {
        yield return new WaitForSeconds(staggerResetTime);
        currentState = Playerstate.idle;
    }

}
