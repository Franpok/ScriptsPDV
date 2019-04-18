using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 10.0f;
    public Rigidbody2D jugador;
    public GameObject bala;
    public float siguienteDisparo = 0.5f;//intervalo temproal entre disparos
    public float tiempoActual = 0.0f;
    public static bool life = true;

    void FixedUpdate()
    {
        jugador = this.GetComponent<Rigidbody2D>();
        jugador.velocity = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0) * velocidad;
    }

    void Update()
    {
        tiempoActual += Time.deltaTime;//se crea el contador de tiempo real 
        if (Input.GetButton("Fire1") && tiempoActual>siguienteDisparo) {//se ejecuta al pulsar ctrl o el boton izquierdo del teclado y con un margen mínimo de 1 segundo
            siguienteDisparo += tiempoActual;
            Instantiate(bala, transform.position, Quaternion.identity);
            siguienteDisparo -= tiempoActual;
            tiempoActual = 0.0f;
        }     
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
