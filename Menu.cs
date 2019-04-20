using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool violento;
    public bool kid;
    public bool info;
    public bool chaos;
    public Texture tex_v_on, tex_n_on, tex_v, tex_n, tex_i, tex_i_on, tex_c, tex_c_on;
    public void Start()
    {
        Time.timeScale = 0;
    }
    void OnMouseUp()//Al hacer click en los botones, cambia de escena
    {
        if (violento)
        {
            SceneManager.LoadScene(2);
            SceneManager.UnloadSceneAsync(0);
        }
        if (kid)
        {
            SceneManager.LoadScene(3);
        }
        if (info)
        {
            SceneManager.LoadScene(1);
        }
        if (chaos)
        {
            SceneManager.LoadScene(5);
        }
    }

    private void OnMouseEnter()//Cambia de sprite si pasas el ratón por encima
    {
        if (violento)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_v_on;
        }
        if (kid)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_n_on;
        }
        if (info)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_i_on;
        }
        if (chaos)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_c_on;
        }
    }

    private void OnMouseExit()//Cambia de sprite si quitas el ratón de encima
    {
        if (violento)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_v;
        }
        if (kid)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_n;
        }
        if (info)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_i;
        }
        if (chaos)
        {
            this.GetComponent<Renderer>().material.mainTexture = tex_c;
        }
    }
}
