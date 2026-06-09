using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    public Transform turrets;
    public Transform spawner;
    public GameObject projectilePrefab;

    public float projectileSpeed = 10f; //meters per second
    public float secondsPerLaunch = 1f;
    float secondsElasped = 0f;
    void Start()
    {


    }

    void Update()
    {
        secondsElasped += Time.deltaTime;

        if (secondsElasped >= secondsPerLaunch)
        {
            GameObject projectile = Instantiate(projectilePrefab, spawner.transform.position, spawner.transform.rotation);
            projectile.GetComponent<Rigidbody>().linearVelocity = spawner.forward * projectileSpeed;

            secondsElasped = 0;
        }
    }
}
