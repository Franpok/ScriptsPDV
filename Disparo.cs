using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform spawn;
    public GameObject proyectil;
    public float siguiente = 1.0f; //intervalo entre disparos
    public float actual = 0.0f; 
    
    void Start()
    {
        spawn = this.gameObject.transform;
    }

    
    void Update()
    {
        disparar();
    }

    public void disparar()
    {
        actual += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            siguiente += actual; //Añade el tiempo actual al siguiente disparo para poder volver a disparar
             //Disparo
            siguiente -= actual; // Se resta para poder resetear luego
            actual = 0.0f; //Se resetea el tiempo
        }
    }
}
