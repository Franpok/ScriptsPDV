using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrucciones : MonoBehaviour
{
    public bool isBack;
    public Texture tex_s_on, tex_s;
    void OnMouseUp()
    {
        if (isBack)
        {
            SceneManager.LoadScene(0);//Vuelve al menú
        }
    }

    private void OnMouseEnter()//Cambia de sprite si pasas el ratón por encima
    {
        if (isBack)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_s_on;
        }
    }

    private void OnMouseExit()//Cambia de sprite si quitas el ratón de encima
    {
        if (isBack)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_s;
        }
    }
}