using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Mechanics test");
    }
}
