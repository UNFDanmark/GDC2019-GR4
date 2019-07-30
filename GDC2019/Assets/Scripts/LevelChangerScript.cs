using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChangerScript : MonoBehaviour
{
    GameManagerScript managerScript;

    public void Restart()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        SceneManager.LoadScene(managerScript.previousScene);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Mechanics test");
    }
}
