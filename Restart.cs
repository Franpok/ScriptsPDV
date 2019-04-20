using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static bool reseteado;
    void OnMouseUp()
    {
        VueltaALMenu.aux = false;
        if (MovBala.auxiliar >= 0)//Si la puntuación viene del modo violento se reinicia este
        {
            BalaEnemigos.vida= false;
            MovBala.auxiliar = 0;
            reseteado = true;
            SceneManager.LoadScene(2);
        }else if (MovBalaRandom.auxiliar >= 0)//Si la puntuación viene del modo caos se reinicia este
        {
            MovBalaRandom.auxiliar = 0;
            SceneManager.LoadScene(5);
        }
        else//En el caso que queda, vuelve al juego infantil
        {
            SceneManager.LoadScene(3);
        }
    }
}
