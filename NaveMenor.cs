using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMenor : MonoBehaviour
{
    public float vel = 10.0f;
    public Rigidbody2D nave;
    public static bool life = true;

    void FixedUpdate()
    {
        nave = this.GetComponent<Rigidbody2D>();
        nave.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * vel;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemigo")
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
            life = false;
        }
    }
}