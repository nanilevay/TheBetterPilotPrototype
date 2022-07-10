using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;
using System.IO;
using System.Linq;

public class HighScores : MonoBehaviour
{
    public List<HighScore> EndlessHighScoresList = new List<HighScore>();

    public List<HighScore> NormalHighScoresList = new List<HighScore>();

    public Transform NormalBox;

    public Transform EndlessBox;

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

        yield break;
    }

    public void CreateFile()
    {
        SaveLastScore();
    }

    public void SaveLastScore()
    {
        string FilePath;
            
            if(GamePrefs.EndlessMode)  
                FilePath = Application.persistentDataPath + "/saveEndless.dat";

            else
                FilePath = Application.persistentDataPath + "/saveNotEndless.dat";

        if (GamePrefs.LastTimer != null)
        {
            StringBuilder FileContent = new StringBuilder();

            FileContent.AppendLine(GamePrefs.LastName + "\t" +
                GamePrefs.LastTimer.ToString());

            File.AppendAllText(FilePath, FileContent.ToString());
        }

        LoadScores();
    }

    public void LoadScores()
    {
        string FilePath = Application.persistentDataPath + "/saveEndless.dat";
        
        FileStream file;

        if (File.Exists(FilePath)) file = File.OpenRead(FilePath);
        else
        {
            Debug.Log("File not found");
            return;
        }

        foreach (string line in System.IO.File.ReadLines(FilePath))
        {
            string[] lines = line.Split('\t');

            EndlessHighScoresList.Add(new HighScore(lines[0], lines[1]));
        }

        file.Close();

        string FilePath2 = Application.persistentDataPath + "/saveNotEndless.dat";

        FileStream file2;

        if (File.Exists(FilePath2)) file2 = File.OpenRead(FilePath2);
        else
        {
            Debug.Log("File not found");
            return;
        }

        foreach (string line in System.IO.File.ReadLines(FilePath2))
        {
            string[] lines = line.Split('\t');

            NormalHighScoresList.Add(new HighScore(lines[0], lines[1]));
        }

        file.Close();

    }
    public void ArrangeScores()
    {
        List<HighScore> SortedList =
            EndlessHighScoresList.OrderBy(o => o.Time).ToList();

        SortedList.Reverse();

        EndlessHighScoresList.Clear();

        EndlessHighScoresList.Add(SortedList[0]);
        EndlessHighScoresList.Add(SortedList[1]);
        EndlessHighScoresList.Add(SortedList[2]);
        EndlessHighScoresList.Add(SortedList[3]);
        EndlessHighScoresList.Add(SortedList[4]);

        DisplayScores(EndlessHighScoresList, EndlessBox);

        List<HighScore> SortedList1 =
            NormalHighScoresList.OrderBy(o => o.Time).ToList();

        NormalHighScoresList.Clear();

        NormalHighScoresList.Add(SortedList1[0]);
        NormalHighScoresList.Add(SortedList1[1]);
        NormalHighScoresList.Add(SortedList1[2]);
        NormalHighScoresList.Add(SortedList1[3]);
        NormalHighScoresList.Add(SortedList1[4]);

        DisplayScores(NormalHighScoresList, NormalBox);
    }

    public void DisplayScores(List<HighScore> Scores, Transform Obj)
    {
        // fix w diff layout unity

        int Counter = 1;

        foreach(HighScore s in Scores)
        {
            TextMeshProUGUI RankNum = Instantiate(TextPrefab, Obj);

            TextMeshProUGUI newTextName = Instantiate(TextPrefab, Obj);

            TextMeshProUGUI newTextScore = Instantiate(TextPrefab, Obj);

            RankNum.transform.parent = Obj; 

            newTextName.transform.parent = Obj;

            newTextScore.transform.parent = Obj;

            RankNum.text = Counter.ToString();

            newTextName.text += s.Name;

            newTextScore.text += s.Time;

            Counter++;
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