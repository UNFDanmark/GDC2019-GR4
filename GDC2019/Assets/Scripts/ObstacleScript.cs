using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleScript : MonoBehaviour

    
{
    GameManagerScript managerScript;
    // Start is called before the first frame update
    void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            managerScript.isDead = true;
        }
        
    }
}
