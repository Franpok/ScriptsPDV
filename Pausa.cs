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
    
        if (Input.GetKeyDown(KeyCode.Escape))//El menú de pausa reacciona cuando se presiona la tecla de escape
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
    public void Continuar()//Al hacer click en reanudar, el tiempo vuelve a ser 1 y se desactiva el menú de pausa
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        JuegoPausado = false;
    }
    void Pausar()//Al hacer escape, el menú de pausa aparece y el tiempo se congela
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        JuegoPausado = true;
    }
    public void Menu()//Al pinchar en menú te devuelve al menú
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Salir()//Al pinchar en salir el juego se cierra
    {
        Application.Quit();
    }
}
