using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class HighScore : MonoBehaviour
{
    public string Name;

    public string Time;
    public HighScore(string name, string time)
    {
        Name = name;
        Time = time;
    }
}
