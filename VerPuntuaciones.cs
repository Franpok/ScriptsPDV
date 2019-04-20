using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerPuntuaciones : MonoBehaviour
{
    //Esta clase usa el patrón proxy, ya que hace de intermediaria entre la clase HighscoreTable y la clase VueltaALMenu
    public GameObject puntuaciones;//Referencia al menú de puntuaciones que se crea con la clase HighscoreTable 
    void Update()
    {
        puntuaciones.SetActive(VueltaALMenu.aux);//Hace que puntuaciones esté activa dependiendo del estado del auxiliar de VueltaALMenu(cambia si pulsas el botón de puntuaciones)
    }
}
