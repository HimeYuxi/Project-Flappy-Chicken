using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public float deadZone = 25;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") || collision.CompareTag("Middle"))
        {
            return; // empêche d'effectuer le reste de la fonction
        }

        Debug.Log(collision.name);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.x > deadZone)
        {
            Destroy(gameObject);
        }
    }

}
