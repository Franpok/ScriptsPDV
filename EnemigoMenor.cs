using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMenor : MonoBehaviour
{
    //Igual que los otros enemigos pero este no dispara
    public Rigidbody2D enemigo; //se referencia a sí mismo
    public float velocidad = 15.0f;
    public static bool vida = true;

    void Start()
    {
        MovBala.auxiliar = -5;
        MovBalaRandom.auxiliar = -5;
        enemigo = this.gameObject.GetComponent<Rigidbody2D>();
        enemigo.velocity = new Vector2(1, 0) * -1 * velocidad;
    }

    void cambioDireccion(int direccion)
    {
        Vector2 nuevaVelocidad = enemigo.velocity;
        nuevaVelocidad.x = velocidad * direccion;
        enemigo.velocity = nuevaVelocidad;
    }
    void bajar()
    {
        Vector2 posicion = transform.position;
        posicion.y -= 1;
        transform.position = posicion;
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "RIGHT")
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
            vida = false;
            Destroy(gameObject);
            c.gameObject.SetActive(false);
        }
        if (c.gameObject.tag == "Barrera")
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
            EfectoSonido.Sonido("muerte");
        }
    }
}
