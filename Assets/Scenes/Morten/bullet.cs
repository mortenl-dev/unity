using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float movementSpeed = 16f;
    Rigidbody2D rb2D;
    float upperThrustLimit = 4f;
    float thrustMultiplier = 3f;
    GameObject Player;
    void Start()
    {
        Destroy(gameObject, 5);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }
    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("trigger enter");

        Player = GameObject.FindGameObjectWithTag("Player");
        rb2D = Player.GetComponent<Rigidbody2D>();

        CreateShockWave();
        if (coll.gameObject.tag == "Wall") {
            Destroy(gameObject); 
        }
          
    }

    void CreateShockWave() {
        float dist = Vector2.Distance(Player.transform.position, transform.position);

        //MAKE THRUST LARGER THE CLOSER TO BULLET PLAYER IS AND ALSO CREATE MAX RADIUS TO PREVENT ADDFORCE EVEN FROM TOO FAR AWAY
        float clampedDistance = upperThrustLimit - dist;
        rb2D.AddForce((Player.transform.position - transform.position).normalized * thrustMultiplier * Mathf.Clamp(clampedDistance, 0, upperThrustLimit), ForceMode2D.Impulse);
    }
}
