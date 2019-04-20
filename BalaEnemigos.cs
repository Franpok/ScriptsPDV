using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigos : MonoBehaviour
{
    public Rigidbody2D proyectil;
    public float velocidad = 10.0f;
    public static bool vida = true;
    public int colision = 0;
    public bool choque = false;
    public static int cambioE = 0;
    

    
    void Start()
    {
        
        proyectil = this.gameObject.GetComponent<Rigidbody2D>();
        proyectil.velocity = new Vector2(0, -1) * velocidad;
        if (Restart.reseteado)
        {
            gameObject.SetActive(false);
        }
    }
    

    void Update()//Actualización de la velocidad dependiendo de si la bala ha chocado o no
    {
        if(choque==false)
            proyectil.velocity = new Vector2(0, -1) * velocidad;
        if (choque==true)
            proyectil.velocity = new Vector2(0, 1) * velocidad;
        
    }
    public void OnBecameInvisible()//El objeto se destruye si es invisible
    {
        gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "Nave")
        {   //Si la bala colisiona con la nave ambas se destruyen y la variable vida se convierte en falsa
            c.gameObject.SetActive(false);
            Destroy(gameObject);
            vida = false;
        }
        if (c.gameObject.tag == "Muro")
        {
            //Si la bala colisiona con los muros, choca(si es el tercer choque, se destruye)
            choque = true;
            colision += 1;
            if (colision >= 3)
                Destroy(gameObject);
        }
        if (c.gameObject.tag == "Top")
        {
            //Si la bala colisiona con el muro de arriba choca(si es el tercer choque, se destruye)
            choque = false;
            colision += 1;
            if (colision >= 3)
                Destroy(gameObject);
        }
        if (c.gameObject.tag == "Barrera")
        {
            //Si la bala colisiona con una barrera, ambas se destruyen y se aumenta en 1 la variable cambioE que determinará el cambio de sprite de los enemigos.
            Destroy(gameObject);
            c.gameObject.SetActive(false);
            cambioE++;
        }
    }
}
