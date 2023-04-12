using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PennyController : MonoBehaviour
{
    public float XPosition = 0f;
    public float MaxYPosition = 4f;
    public float MinYPosition = -4f;

    Rigidbody2D rb;
    public GameManager gameManager;
    AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Reset()
    {
        rb.Sleep();
        transform.position = new Vector2(XPosition, Random.Range(MinYPosition, MaxYPosition));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "R3")
        {
            gameManager.Score += 20;
            Debug.Log("+20");
        }

        if (collision.gameObject.name == "R2")
        {
            gameManager.Score += 30;
            Debug.Log("+30");
        }

        if (collision.gameObject.name == "R1")
        {
            gameManager.Score += 50;
            Debug.Log("+50");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "R3")
        {
            gameManager.Score -= 10;
            Debug.Log("-10");
        }

        if (collision.gameObject.name == "R2")
        {
            gameManager.Score -= 20;
            Debug.Log("-20");
        }

        if (collision.gameObject.name == "R1")
        {
            gameManager.Score -= 40;
            Debug.Log("-40");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}
