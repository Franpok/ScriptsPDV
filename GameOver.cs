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
        if(MovBala.auxiliar>=0)
        texto.GetComponent<Text>().text = ""+MovBala.auxiliar;
        else if(MovBalaRandom.auxiliar>=0)
        texto.GetComponent<Text>().text = "" + MovBalaRandom.auxiliar;

    }
}
