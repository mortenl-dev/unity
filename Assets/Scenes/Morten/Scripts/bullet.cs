using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float movementSpeed = 16f;
    GameObject Player;
    //Rigidbody2D rb;    
    void Start()
    {   
        //rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MoveInDirection(gameObject);
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }

    //INCASE THIS IS NEEDED IN THE FUTURE

    /*public void MoveInDirection(GameObject obj)
    {
        // Get the forward direction of the object
        Vector2 direction = obj.transform.up;

        // Normalize the direction vector to ensure constant speed in any direction
        direction.Normalize();

        // Calculate the desired position to move towards
        Vector2 newPosition = rb.position + direction * movementSpeed * Time.fixedDeltaTime;

        // Move the object using Rigidbody.MovePosition
        rb.MovePosition(newPosition);
    }*/
    bool destroyed = false;
    void OnTriggerEnter2D(Collider2D coll) {
        if (!destroyed) {
            
            Debug.Log("trigger enter");

            GameObject Parent = transform.parent.gameObject;

            
            if (coll.gameObject.tag == "Wall") {
                Debug.Log("shockwaving");
                StartCoroutine(Parent.GetComponent<player_movement>().CreateShockWave(gameObject));

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                destroyed=true;
                                
                Destroy(gameObject,0.2f); 
            }
        }
    }
}
