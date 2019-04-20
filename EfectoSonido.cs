using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    public static AudioClip sonidoMuerte;
    static AudioSource audioSrc;
    
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        sonidoMuerte = Resources.Load<AudioClip>("Comer Chuche");//Le asigna al clip sonidoMuerte el .wav que usaremos para esta accion
    }

    public static void Sonido(string clip)
    {
        switch (clip) {//se usa un switch por si se añaden otros efectos de sonido que sean llamados por otros string diferentes
            case "muerte":
                audioSrc.PlayOneShot(sonidoMuerte);//si se llama a la función con "muerte" se escuchará Comer Chuche.wav
            break;
        }   
    }
}
