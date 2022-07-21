using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject PauseMenu;

    public SensorListener Listener;

    public int timer = 0;

    void FixedUpdate()
    {
        timer += 1;

        if ((Input.GetKeyDown(KeyCode.Escape)) || (Listener.redMorse == 0 && 
                Listener.redButton == 0 && timer > 3))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            gameIsPaused = true;
        }
    }
}