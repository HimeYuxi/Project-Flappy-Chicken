using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject bottomPipe;
    public GameObject topPipe;

    public float speed = 5f;

    private bool shouldMove = false;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }
    
    private void MoveDown()
    {
        float targetPosition = topPipe.transform.position.y - 28f;
        bottomPipe.transform.position += Vector3.down * speed * Time.deltaTime;

        // Si la position Y atteint -14, arrêtez le mouvement
        if (bottomPipe.transform.position.y <= targetPosition)
        {
            shouldMove = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            MoveDown();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feather"))
        {
            shouldMove = true;
        }
    }
}
