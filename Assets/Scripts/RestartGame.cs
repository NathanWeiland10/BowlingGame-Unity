// This code is used to allow the player to choose to start a new game or to load the main menu:

using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("BowlingAlley");
        Time.timeScale = 1f;
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
