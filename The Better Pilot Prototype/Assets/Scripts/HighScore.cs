using UnityEngine;
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
