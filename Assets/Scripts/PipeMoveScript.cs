using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 4f;
    public float deadZone = -20f;
    public BirdScript birdScript;
    public GameObject pipeSpawner;
    public float heightMoveRange = 5f;

    public float amp;
    public float freq;
    private Vector3 initialPosition;



    // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Chicken").GetComponent<BirdScript>();
        pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner");
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive)
        {
            Vector3 newPosition = new Vector3(
                transform.position.x - moveSpeed * Time.deltaTime,
                Mathf.Sin(Time.time * freq) * amp + initialPosition.y,
                transform.position.z
            );

            transform.position = newPosition;

        }


        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        } 
    }

    
}



/*    private bool shouldMoveUp = true;      
 *    private bool shouldMoveDown = false;      
 *      
 *    private bool hasMovedUp = false;     
 *    private bool hasMovedDown = false;
 *     
 *      if (shouldMoveUp)
        {
            MoveUp();
        }

        if (shouldMoveDown)
        {
            MoveDown();
        }


    private void MoveUp()
    {
        if (CompareTag("RedPipe") && )
        {
            Debug.Log("MoveUp Called");
            float heightPoint = initialPosition.y + heightMoveRange;
            Vector3 targetPositionUp = initialPosition + Vector3.up * heightPoint;
            transform.position += (Vector3.up * moveSpeed) * Time.deltaTime;

            if (transform.position.y >= targetPositionUp.y)
            {
                shouldMoveUp = false;
                shouldMoveDown = true;
            }

        }
    }
    
    private void MoveDown()
    {
        if (CompareTag("RedPipe"))
        {
            Debug.Log("MoveDown Called");
            float lowPoint = initialPosition.y - heightMoveRange;
            Vector3 targetPositionDown = initialPosition + Vector3.down * lowPoint;
            transform.position += (Vector3.down * moveSpeed) * Time.deltaTime;

            if (transform.position.y <= targetPositionDown.y)
            {
                shouldMoveDown = false;
                shouldMoveUp = true;
            }
        }
    }


maintenant pour les TargetRedPipe, la cible fait que le bottomPipe se baisse de 14 unités par rapport à sont point de spawn, mais cela rend l'abaissement non uniform lorsque le pipe monte et descend 

*/



