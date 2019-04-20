using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    
    private void Awake() { 
        //Meterá la puntuación y nombre dependiendo del modo del que se provenga
            if (MovBala.auxiliar >= 0)
                AddHighscoreEntry(MovBala.auxiliar, "AAA");
            else if (MovBalaRandom.auxiliar > 0)
                AddHighscoreEntry(MovBalaRandom.auxiliar, "CCC");
            else{
                AddHighscoreEntry(0, "NNN");
            }
        
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        // Ordena la lista de mayor a menor puntuación
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        //Añade las puntuaciones a la lsita, una a una
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);    
        }
    }

    //Crea el template de la tabla de puntuaciones
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = .75f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);//Separa las puntuaciones dependiendo del peusto en el que estén
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)//Dependiendo del puesto añadirá el ordinal que le corresponde
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Destaca el primer puesto
        if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.red;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.red;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.red;
        }

        transformList.Add(entryTransform);
    }
    //Añade una entrada a la tabla
    private void AddHighscoreEntry(int score, string name) {
        // Se crea el HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        //Se cargan las Highscores guardadas anteriormente
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // Si no hay tabla, se inicializa
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        //Añade una nueva entrada
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Se guarda las Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Representa una única entrada
     * */
    [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }

}
