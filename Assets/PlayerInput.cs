using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Raycast))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] Raycast controller;
    [SerializeField] float gravity, moveSpeed = 15f, jumpVelocity, friction, knockback;
    public float Knockback { get { return knockback; } }

    [SerializeField] float jumpHeight, timeToReachJumpHeight;
    [SerializeField] float decelerationVolx, decelerationVolx2;
    [SerializeField] float jumpDelay = 0.2f, jumpDelayTime, groundedDelay = 0.2f, groundedDelayTime;
    [SerializeField] const float decelerationTime = 0.2f;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] bool facingRight = true; public bool FacingRight { get { return facingRight; } }

    bool jump, shoot, fallThrough;
    [SerializeField] Vector2 velocity, inputVelocity; public Vector2 Velocity { get { return velocity; } }
    [SerializeField] public Vector2 shootVelocity, knockbackVelocity;
    void Start()
    {
        controller = GetComponent<Raycast>();
        animationManager = GetComponent<AnimationManager>();
        gravity = -(2 * jumpHeight) / (timeToReachJumpHeight * timeToReachJumpHeight);
        jumpVelocity = Mathf.Abs(gravity) * timeToReachJumpHeight;
        friction = moveSpeed;

    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            if (controller.collisions.above || controller.collisions.below)
            {
                velocity.y = 0;
            }
            else
                animationManager.ChangeAnimationState(AnimationStates.Jumping.ToString());

            Vector2 input = new Vector2();

            if (TriggerElevator.playerInput)
            {
                input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                jumpDelayTime -= Time.deltaTime;   //Timer for jump delay 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpDelayTime = jumpDelay;   //Reset the timer when pressing jump
                }

                groundedDelayTime -= Time.deltaTime;   //Timer for grounded delay 
                if (controller.collisions.below)
                {
                    groundedDelayTime = groundedDelay;   //Reset the timer when grounded
                }

                if (jumpDelayTime > 0 && groundedDelayTime > 0) //Jump
                {
                    jumpDelayTime = 0;    //reset the timers again
                    groundedDelayTime = 0;
                    jump = true;
                }

                if (input.y == -1 && controller.onPlatform) //Press down to fall through platform
                {
                    fallThrough = true;

                }
            }

            if (input.x != 0) //Move left and right 
            {
                inputVelocity.x = input.x * moveSpeed;

                if (controller.collisions.below)
                    animationManager.ChangeAnimationState(AnimationStates.Walking.ToString());
            }
            else
            {
                inputVelocity.x = 0;   //instantly stop for snappy movement

                if (controller.collisions.below)
                    animationManager.ChangeAnimationState(AnimationStates.Idle.ToString());
            }

            if (shootVelocity.y > 0)             //always make the player go up when shooting 
                shoot = true;

        }

        shootVelocity.x = Mathf.SmoothDamp(shootVelocity.x, 0, ref decelerationVolx, decelerationTime);
        knockbackVelocity.x = Mathf.SmoothDamp(knockbackVelocity.x, 0, ref decelerationVolx2, decelerationTime);
        velocity.x = inputVelocity.x + shootVelocity.x + knockbackVelocity.x; //add horizontal component of gunshot momentum after damping it

        if (knockbackVelocity.y > 0)    //always make the player get knocked back when taking damage
        {
            velocity.y = knockbackVelocity.y;
            velocity.x = knockbackVelocity.x;
        }

        velocity.y += gravity * Time.deltaTime;

    }


    private void FixedUpdate()
    {
        if (jump)
        {
            velocity.y = jumpVelocity;
            jump = false;
        }
        if (shoot)
        {
            velocity.y = shootVelocity.y;
            shoot = false;
        }
        if (fallThrough)
        {
            StartCoroutine("FallThrough");
            fallThrough = false;
        }
        controller.Move(velocity * Time.deltaTime);
        shootVelocity.y = 0;
        knockbackVelocity.y = 0;
    }
    IEnumerator FallThrough()
    {
        controller.BrickPlatformCollisionMask = LayerMask.GetMask("Ignore Raycast");
        yield return new WaitForSeconds(0.1f);
        controller.BrickPlatformCollisionMask = LayerMask.GetMask("Platform");
    }

    public enum AnimationStates
    {
        Idle,
        Walking,
        Jumping,
        Gunshot
    }

}