﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTocho : MonoBehaviour
{
    public Rigidbody2D enemigoDonut;
    public float velocidad = 25.0f;
    public GameObject bala;
    public float minTime = 5.0f;
    public float maxTime = 10.0f;
    public float baseWaitTime = 5.0f;
    public float spawnTime = 10.0f;
    
    void Start()
    {
       // InvokeRepeating("Spawn", 1.0f, 10.0f);
        //InvokeRepeating("Disparo", 0.0f, 10.0f);
    }
    void Spawn()
    {
        enemigoDonut = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D instance = Instantiate(enemigoDonut);
        instance.velocity = new Vector2(1, 0) * 1 * velocidad;
    }

    void FixedUpdate()
    {
        if (Time.time % 10 == 0)
        {
            Spawn();
            Destroy(gameObject);
        }
        if (Time.time > baseWaitTime)// && Time.time < 3.0f)
        {
            baseWaitTime = baseWaitTime + Random.Range(.1f,.2f);
            Instantiate(bala, transform.position, Quaternion.identity);

        }
        //if (Time.time == 5.0f)
          //  Destroy(enemigoDonut);
       

    }
}
