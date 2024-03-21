// The sprite will fall under its weight.  After a short time the
// sprite will start its upwards travel due to the thrust force that
// is added in the opposite direction.

using UnityEngine;
using System.Collections;

public class exampleAddForce : MonoBehaviour
{



    //TODO
    //ADD PLAYER OBJECT TO CALCULATE DISTANCE BETWEEN BULLET IMPACT AND PLAYER TO INCREMENT THRUST VARIABLE IF WITHIN CERTAIN DISTANCE
    private Rigidbody2D rb2D;

    private float thrust = 15f;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
    }
}