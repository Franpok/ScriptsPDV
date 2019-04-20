using System.Collections;
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

    void Spawn()//Método que hace que el donut aparezca y se mueva por el eje X
    {
        enemigoDonut = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D instance = Instantiate(enemigoDonut);
        instance.velocity = new Vector2(1, 0) * 1 * velocidad;
    }

    void FixedUpdate()
    {
        if (Time.time % 10 == 0)//Aparecerá cada 10 segundos
        {
            Spawn();
            Destroy(gameObject);
        }
        if (Time.time > baseWaitTime)//Disparos del jefe(Mucho más frecuentes que los enemigos normales)
        {
            baseWaitTime = baseWaitTime + Random.Range(.1f,.2f);
            Instantiate(bala, transform.position, Quaternion.identity);
        }
    }
}
