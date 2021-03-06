﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovBala : MonoBehaviour
{
    public Rigidbody2D proyectil; //referencia al rigidbody2d
    public float velocidad = 10.0f;
    public static int auxiliar;
    public int colision = 0;
    public bool choque = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public static int cambio = 0;
    public AudioClip muerte;

    void Start()
    {
        Time.timeScale = 1;
        MovBala.auxiliar = 0;
        MovBalaRandom.auxiliar = -5;
        proyectil = this.gameObject.GetComponent<Rigidbody2D>();
        proyectil.velocity = new Vector2(0, 1) * velocidad;
    }

    void Update()
    {
        //Al chocarse cambia de sprite y dirección a la contraria
        if (choque == true) {
            proyectil.velocity = new Vector2(0, -1) * velocidad;
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }  
        if (choque == false)
        {
            proyectil.velocity = new Vector2(0, 1) * velocidad;
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }     
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Muro")
        {
            choque = false;
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
            //Si choca con un enemigo lo mata, aumenta la puntuación en 100 y reproduce el sonido de muerte
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

    void aumentarPuntuacion()//Método que aumenta la puntuación en 100
    {
        var textoUI = GameObject.Find("Score").GetComponent<Text>();
        int puntuacion = int.Parse(textoUI.text);
        puntuacion += 100;
        auxiliar = puntuacion;
        textoUI.text = puntuacion.ToString();
    }
}
