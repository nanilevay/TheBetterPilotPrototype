using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScores : MonoBehaviour
{
    public List<HighScore> HighScoresList = new List<HighScore>();

    public Transform Box;

    public TextMeshProUGUI TextPrefab;

    // Update is called once per frame
    void Start()
    {
        //LastPlayerName.text = GamePrefs.LastName;
        StartCoroutine(Scores());
    }

    public IEnumerator Scores()
    {
        CreateFile();

        ArrangeScores();
        DisplayScores();

        yield break;
    }

    public void CreateFile()
    {
        // Get a string with the correct path to the saves 
        // folder with the user-given file name
        string FilePath = Application.persistentDataPath + "/save.dat";

        // Replace all text in file with an empty string
        //File.WriteAllText(FilePath, String.Empty);

        SaveLastScore(FilePath);
    }

    public void SaveLastScore(string FilePath)
    {
        // ADD THIS BACKJ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //StringBuilder FileContent = new StringBuilder();

        //FileContent.AppendLine(GamePrefs.LastName + "\t" + 
        //    GamePrefs.LastTimer.ToString() + "\n");

        //File.AppendAllText(FilePath, FileContent.ToString());

        LoadScores(FilePath);
    }

    public void LoadScores(string FilePath)
    {
        FileStream file;

        if (File.Exists(FilePath)) file = File.OpenRead(FilePath);
        else
        {
            Debug.Log("File not found");
            return;
        }

        //using (StreamReader streamReader = File.OpenText(FilePath))
        //{
        //    //LastPlayerName.text = streamReader.ReadToEnd();

        //    LastPlayerName.text = streamReader.ReadLine();
        //    streamReader.
        //}

        foreach (string line in System.IO.File.ReadLines(FilePath))
        {
            string[] lines = line.Split('\t');

            Debug.Log(lines[0] + " + " + lines[1]);

            HighScoresList.Add(new HighScore(lines[0], lines[1]));
        }


        file.Close();
    }
    public void ArrangeScores()
    {
        // fix
        //HighScoresList.Sort();

        List<HighScore> SortedList = HighScoresList.OrderBy(o => o.Time).ToList();

        HighScoresList = SortedList;
    }

    public void DisplayScores()
    {
        // fix w diff layout unity

        foreach(HighScore s in HighScoresList)
        {
            TextMeshProUGUI newText = Instantiate(TextPrefab, Box);

            newText.transform.parent = Box;

            newText.text += s.Name + ": " + s.Time + "\n";
        }
      
    }

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}