using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{

    public GameObject pipe;
    public GameObject targetPipe;
    public GameObject redPipe;
    public GameObject targetRedPipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffSet = 5;
    public BirdScript birdScript;
    public LogicScript logic;


    // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Chicken").GetComponent<BirdScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;
            }
        }

    }
    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;


        if (Random.value < 0.6)
        {
            if (Random.value < 0.6)
            {
                SpawnGreenPipe();
            }
            else if (logic.playerScore >= 10)
            {
                SpawnTargetGreenPipe();
            }
            else
            {
                SpawnGreenPipe();
            }

        }

        else if (logic.playerScore >= 20)
        {
            if (Random.value < 0.6)
            {
                SpawnRedPipe();
            }
            else if (logic.playerScore >= 30)
            {
                SpawnTargetRedPipe();
            }
            else if (Random.value < 0.33)
            {
                SpawnGreenPipe();
            }
            else if (Random.value < 0.33)
            {
                SpawnTargetGreenPipe();
            }
            else
            {
                SpawnRedPipe();
            }
        }

        else
        {
            SpawnPipe();
        }



        void SpawnGreenPipe()
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }

        void SpawnTargetGreenPipe()
        {
            Instantiate(targetPipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }

        void SpawnRedPipe()
        {
            Instantiate(redPipe, new Vector3(transform.position.x, 0, 0), transform.rotation);
        }

        void SpawnTargetRedPipe()
        {
            Instantiate(targetRedPipe, new Vector3(transform.position.x, 0, 0), transform.rotation);
        }

    }


}
