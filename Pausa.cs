using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausa : MonoBehaviour
{
    private void Start()
    {
        menuPausa.SetActive(false);
    }
    public static bool JuegoPausado = false;
    public GameObject menuPausa;
    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        } 
    }
    public void Continuar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        JuegoPausado = false;
    }
    void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        JuegoPausado = true;
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
