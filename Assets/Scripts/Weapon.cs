using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject featherPrefab;
    public BirdScript birdScript;

    private void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Chicken").GetComponent<BirdScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive && Input.GetButtonDown("Fire1") && !LogicScript.gameIsPaused)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newFeather = Instantiate(featherPrefab, firePoint.position, firePoint.rotation);
        newFeather.transform.eulerAngles = new Vector3(0, 0, 55); // Rotation vers la droite
    }
}
