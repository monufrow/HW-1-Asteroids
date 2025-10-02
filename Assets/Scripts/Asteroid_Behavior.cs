using UnityEngine;

public class Asteroid_Behavior : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Asteroid hit the player!");
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boundary"))
        {
            Debug.Log("Asteroid hit the boundary and is destroyed.");
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player_Attack"))
        {
            Debug.Log("Asteroid was destroyed by an attack!");
            Destroy(gameObject);
        }
    }
}
