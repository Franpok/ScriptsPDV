using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void Start(){}

    void Update()
    { 
        if ((MovBala.auxiliar==2000) ||(BalaEnemigos.vida ==false) || (Enemigo.vida == false) || (Jugador.life == false) || (NaveMenor.life == false) || (EnemigoMenor.vida == false))
        {
            //Se resetean los valores para que se pueda reiniciar el juego en modo violento
            //BalaEnemigos.vida = true;
            Enemigo.vida = true; 
            Jugador.life = true; 
            NaveMenor.life = true; 
            EnemigoMenor.vida = true; 
            SceneManager.LoadScene(4); //Se carga la pantalla final
        }else if ((MovBalaRandom.auxiliar == 2000) || (BalaenemigoRandom.vida == false) || (Enemigo.vida == false) || (Jugador.life == false) || (NaveMenor.life == false) || (EnemigoMenor.vida == false))
        {
            //Se resetean los valores para que se pueda reiniciar el juego en modo caos
            BalaenemigoRandom.vida = true;
            Enemigo.vida = true;
            Jugador.life = true;
            NaveMenor.life = true;
            EnemigoMenor.vida = true;
            SceneManager.LoadScene(4); //Se carga la pantalla final
        }
    }
}