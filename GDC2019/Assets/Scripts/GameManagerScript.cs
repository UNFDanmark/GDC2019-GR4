using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public AudioClip winJingle;
    public bool partPickedUp = false;
    public bool partReturned = false;
    public bool isDead = false;
    public GameObject spaceshipLight;
    public int previousScene;
    

    int currentScene;
    AudioSource source;
       
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] tempManagers = GameObject.FindGameObjectsWithTag("GameManager");
        spaceshipLight = GameObject.Find("Spaceship Light");
        source = GetComponent<AudioSource>();
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
        
        
        currentScene = SceneManager.GetActiveScene().buildIndex;        
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < 1 && spaceshipLight.activeSelf || spaceshipLight == null)
        {
            spaceshipLight = GameObject.Find("Spaceship Light");
            spaceshipLight.SetActive(false);
        }
        
        if (currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
        if (partReturned == true)
        {
            //you win
            previousScene = currentScene;
            currentScene++;
            partPickedUp = false;
            partReturned = false;
            source.PlayOneShot(winJingle);
            StartCoroutine(ChangeSceneEnumerator(currentScene));
        }
       
        if (isDead == true)
        {            
            isDead = false;
            previousScene = currentScene;
            StartCoroutine(ChangeSceneEnumerator(1));
        }
    }

    IEnumerator ChangeSceneEnumerator(int buildIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(buildIndex);
    }
}
