using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool partPickedUp = false;
    public bool partReturned = false;
    public bool isDead = false;
    public GameObject spaceshipLight;

    int currentScene;
   
    
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] tempManagers = GameObject.FindGameObjectsWithTag("GameManager");
        spaceshipLight = GameObject.Find("Spaceship Light");
        foreach (GameObject manager in tempManagers)
        {
            if ( manager != gameObject)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);     
            }
        }
        
        spaceshipLight.SetActive(false);
        currentScene = SceneManager.GetActiveScene().buildIndex;        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
        if (partReturned == true)
        {
            //you win
            currentScene++;
            partPickedUp = false;
            partReturned = false;
            SceneManager.LoadScene(currentScene);
        }
        //Delete before build, ONLY FOR TESTING
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Mechanics test");
        }
        if (isDead == true)
        {
            SceneManager.LoadScene("GameOver");
            isDead = false;
        }
    }
}
