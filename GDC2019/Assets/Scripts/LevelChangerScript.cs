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
}
