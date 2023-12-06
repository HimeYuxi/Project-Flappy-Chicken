using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Sprite[] animationSprites;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float deadZone = -20;

    private SpriteRenderer spriteRenderer;
    private Coroutine flapAnimationCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                // We check if a FlapAnimation Coroutine is already running
                if (flapAnimationCoroutine != null)
                {
                    StopCoroutine(flapAnimationCoroutine);
                }

                // We start a new FlapAnimation Coroutine
                flapAnimationCoroutine = StartCoroutine(FlapAnimation());
                myRigidbody.velocity = Vector2.up * flapStrength;
            }

            if (transform.position.y < deadZone)
            {
                Death();
            }
        }
    }

    IEnumerator FlapAnimation()
    {
        spriteRenderer.sprite = this.animationSprites[0];
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.sprite = this.animationSprites[1];
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = this.animationSprites[0];
    }

    void Death()
    {
        if (birdIsAlive)
        {
            logic.gameOver();
            if (flapAnimationCoroutine != null)
            {
                StopCoroutine(flapAnimationCoroutine);
            }
            spriteRenderer.sprite = this.animationSprites[2];
            birdIsAlive = false;
            LogicScript.gameIsOver = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }

    private void OnBecameInvisible()
    {
        Death();
    }
}