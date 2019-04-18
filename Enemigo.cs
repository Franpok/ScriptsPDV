using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Rigidbody2D enemigo; //se referencia a sí mismo
    public float velocidad = 25.0f;
    public float minTime = 1.0f;
    public float maxTime = 20.0f;
    public float baseWaitTime; 
    public GameObject bala;
    public static bool vida = true;
    public Sprite sprite1;
    public Sprite sprite2;

    void Start()
    {
        Application.targetFrameRate = 300;
        baseWaitTime = Random.Range(2f, 6f);
        enemigo = this.gameObject.GetComponent<Rigidbody2D>();
        enemigo.velocity= new Vector2(1, 0) *-1 * velocidad;
    }
    void Awake()
    {
        // Make the game run as fast as possible in Windows
        
    }
    void cambioDireccion(int direccion)
    {
        Vector2 nuevaVelocidad = enemigo.velocity;
        nuevaVelocidad.x = velocidad * direccion;
        enemigo.velocity = nuevaVelocidad;
    }

    void cambioSprite()
    {
        if (MovBala.cambio == 0 && BalaEnemigos.cambioE == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (MovBala.cambio == 0 && BalaEnemigos.cambioE % 2 == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;

        }
        else if (MovBala.cambio == 0 && BalaEnemigos.cambioE == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 0 && BalaEnemigos.cambioE == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;

        }
        else if (MovBala.cambio == 0 && BalaEnemigos.cambioE == 4)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 1 && BalaEnemigos.cambioE % 2 == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;

        }
        else if (MovBala.cambio == 1 && BalaEnemigos.cambioE == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 1 && BalaEnemigos.cambioE == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;

        }
        else if (MovBala.cambio == 1 && BalaEnemigos.cambioE == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 2 && BalaEnemigos.cambioE == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 2 && BalaEnemigos.cambioE == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;

        }
        else if (MovBala.cambio == 2 && BalaEnemigos.cambioE == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 3 && BalaEnemigos.cambioE == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;

        }
        else if (MovBala.cambio == 3 && BalaEnemigos.cambioE == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
        else if (MovBala.cambio == 4 && BalaEnemigos.cambioE == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;

        }
    }

    void bajar()
    {
        Vector2 posicion = transform.position;
        posicion.y -= 1;
        transform.position = posicion;
    }
      void OnCollisionEnter2D(Collision2D c) 
    {
        if(c.gameObject.name == "RIGHT")
        {
            cambioDireccion(-1);
            bajar();
        }
        if (c.gameObject.name == "LEFT")
        {
            cambioDireccion(1);
            bajar();
        }
        if (c.gameObject.tag == "Jugador")
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
            vida = false;
        }
        if (c.gameObject.tag == "Barrera")
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
        }
    }
    void FixedUpdate()
    {
        
        if (Time.time > baseWaitTime)
        {
            baseWaitTime = baseWaitTime + Random.Range(minTime, maxTime);

            Instantiate(bala, transform.position, Quaternion.identity);
        }
        cambioSprite();
    }
  
}
