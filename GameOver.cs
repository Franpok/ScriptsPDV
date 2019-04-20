using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject texto;
     void Update()
     {
        //Dependiendo del modo en el que se haya jugado por última vez, elegirá una condición u otra
        if(MovBala.auxiliar>0)
        texto.GetComponent<Text>().text = ""+MovBala.auxiliar;//Modo violento
        else if(MovBalaRandom.auxiliar>0)
        texto.GetComponent<Text>().text = "" + MovBalaRandom.auxiliar;//Modo caos
        else
        {
            texto.GetComponent<Text>().text = "0";//Modo infantil
        }

    }
}
