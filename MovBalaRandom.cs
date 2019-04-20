using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovBalaRandom : MonoBehaviour
{
    public Rigidbody2D proyectil; //referencia al rigidbody2d
    public float velocidad = 20.0f;
    public static int auxiliar;
    public int colision = 0;
    public bool choque = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public static int cambio = 0;
    public Vector2 ve;
    //Igual que MovBala pero esta vez el movimiento sobre el eje X será impredecible
    void Start()
    {
        Time.timeScale = 1;
        MovBala.auxiliar = -5;
        MovBalaRandom.auxiliar = 0;
        proyectil = this.gameObject.GetComponent<Rigidbody2D>();
        ve =new Vector2(Random.Range(-1.0f,1.0f), 1);
        proyectil.velocity = ve * velocidad;
    }
    
    void Update()
    {
        if (choque == true)
        {
            proyectil.velocity = ve * -velocidad;
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if (choque == false)
        {
            proyectil.velocity = ve * velocidad;
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Muro")
        {
            choque = true;
            colision += 1;
            if (colision >= 3)
                Destroy(gameObject);
        }
        if (c.gameObject.tag == "Top")
        {
            choque = true;
            colision += 1;
            if (colision >= 3)
                Destroy(gameObject);
        }
        if (c.gameObject.tag == "Enemigo")
        {
            aumentarPuntuacion();
            Destroy(gameObject);
            Destroy(c.gameObject);
            EfectoSonido.Sonido("muerte");
        }
        if (c.gameObject.tag == "Barrera")
        {
            Destroy(gameObject);
            c.gameObject.SetActive(false);
            cambio++;
        }
    }

    void aumentarPuntuacion()
    {
        var textoUI = GameObject.Find("Score").GetComponent<Text>();
        int puntuacion = int.Parse(textoUI.text);
        puntuacion += 100;
        auxiliar = puntuacion;
        textoUI.text = puntuacion.ToString();
    }
}
