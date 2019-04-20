using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VueltaALMenu : MonoBehaviour
{
    public bool isBack, isRestart, isMenu, isP;
    public static bool aux=false;
    public Texture tex_s_on, tex_s, tex_r_on, tex_r, tex_m, tex_m_on, tex_p, tex_p_on;

    void OnMouseUp()//Al hacer click a los botones cambia de escena o muestran el menú de puntuaciones
    {
        if (isBack)
        {
            Application.Quit();
        }
        else if (isMenu)
        {
            SceneManager.LoadScene(0);
            aux = false;
        }
        else if (isP)
        {
            aux = true;
        }
    }
    private void OnMouseEnter()//Cambia de textura al estar encima del botón
    {
        if (isBack)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_s_on;
        }
        else if(isRestart)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_r_on;
        }
        else if (isMenu)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_m_on;
        }else if (isP)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_p_on;
        }
    }

    private void OnMouseExit()//Cambia de textura al salir del botón
    {
        if (isBack)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_s;
        }
        else if(isRestart)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_r;
        }
        else if (isMenu)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_m;
        }
        else if (isP)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_p;
        }
    }
}
