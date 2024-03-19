using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectExplosion : MonoBehaviour
{   
    [SerializeField] GameObject Player;
    private Rigidbody2D rb2D;

    private float upperThrustLimit = 4f;
    private float thrustMultiplier = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("q pressed");
            float dist = Vector2.Distance(Player.transform.position , this.transform.position);

            //MAKE THRUST LARGER THE CLOSER TO BULLET PLAYER IS AND ALSO CREATE MAX RADIUS TO PREVENT ADDFORCE EVEN FROM TOO FAR AWAY
            float clampedDistance = upperThrustLimit - dist;
            rb2D.AddForce(transform.up * thrustMultiplier * Mathf.Clamp(clampedDistance, 0, upperThrustLimit), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D() {
        Debug.Log("trigger enter");
        float dist = Vector2.Distance(Player.transform.position , this.transform.position);
        rb2D.AddForce(transform.up * dist, ForceMode2D.Impulse);
    }
}
