using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 movement;
    private Vector2 startPosition;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
        if(transform.position.y > -1.0f || transform.position.y < -10.0f || transform.position.x > 20.0f || transform.position.x < -20.0f)
        {
            Respawn();
        }
    }
    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit by an enemy!");
            Respawn();
        }
    }
    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        movement = Vector2.zero;
    }

}
