using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void OnMouseUp()
    {
        if (MovBala.auxiliar >= 0)
        {
            MovBala.auxiliar = 0;
            SceneManager.LoadScene(2);
        }else if (MovBalaRandom.auxiliar >= 0){
            MovBalaRandom.auxiliar = 0;
            SceneManager.LoadScene(5);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
        
        
        
        
        //Application.LoadLevel(2);

    }
}
