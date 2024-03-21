using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    float horizontal;
    float speed = 4f;
    float jumpingPower = 8f;
    bool isFacingRight = true;
    public bool shocked = false;
    [SerializeField] bullet bull;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject Player;

    float upperThrustLimit = 4f;
    float thrustMultiplier = 12f;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        //THIS MESSES WITH KNOCKBACK FROM THE SIDE

        // Calculate the force needed to move the object
        //float forceX = horizontal * rb.mass / Time.fixedDeltaTime;

        // Apply the force to move the object
       // rb.AddForce(new Vector2(forceX, 0));
        if (IsGrounded() && !shocked) {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        //Debug.Log(shocked);
        
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = Player.transform.localScale;
            localScale.x *= -1f;
            Player.transform.localScale = localScale;
        }
    }
    public IEnumerator CreateShockWave(GameObject bullet) {
        float dist = Vector2.Distance(bullet.transform.position, Player.transform.position);
        Debug.Log(dist);
            shocked = true;
        

            //MAKE THRUST LARGER THE CLOSER TO BULLET PLAYER IS AND ALSO CREATE MAX RADIUS TO PREVENT ADDFORCE EVEN FROM TOO FAR AWAY
            float clampedDistance = upperThrustLimit - dist;

            //rb2D.velocity = new Vector2(clampedDistance, rb2D.velocity.y);
            
            //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            Debug.Log((Player.transform.position- bullet.transform.position).normalized * thrustMultiplier * Mathf.Clamp(clampedDistance, 0, upperThrustLimit));
            rb.AddForce((Player.transform.position- bullet.transform.position).normalized * thrustMultiplier * Mathf.Clamp(clampedDistance, 0, upperThrustLimit), ForceMode2D.Impulse);
            yield return new WaitForSecondsRealtime(0.1f);
            shocked = false;
        
        
    }
}