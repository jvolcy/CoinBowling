using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour
{

    Rigidbody2D rb;
    public float HForce = 500f;
    public float VForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(VForce * Vector2.up);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(HForce * Vector2.right);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TopWall") rb.AddForce(VForce * Vector2.down);
        if (collision.gameObject.name == "BottomWall") rb.AddForce(VForce * Vector2.up);
    }
}
