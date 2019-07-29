using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChangerScript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Mechanics test");
    }
}
