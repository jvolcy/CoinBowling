using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody2D rb;
    public float Force = 500f;
    public float Speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Input.GetAxis("Vertical") * Vector2.up);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Force * Vector2.right);
        }
        
    }
}
