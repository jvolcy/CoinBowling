using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterController : MonoBehaviour
{

    Rigidbody2D rb;
    public float Force = 500f;
    public float Speed = 0.1f;
    public float XPosition = -6.5f;
    public float YPosition = 0f;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.bAiming) return;
        transform.Translate(Speed * Input.GetAxis("Vertical") * Vector2.up, Space.World);        
    }

    public void Reset()
    {
        rb.Sleep();
        //rb.velocity = Vector2.zero;
        transform.position = new Vector2(XPosition, YPosition);
    }

    public void Shoot()
    {
        rb.AddForce(Force * Vector2.right);
    }
}
