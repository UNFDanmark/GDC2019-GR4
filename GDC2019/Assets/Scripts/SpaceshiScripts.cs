using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshiScripts : MonoBehaviour
{
    

    GameManagerScript managerScript;
    // Start is called before the first frame update
    void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player") == true)
        {
            
            if (managerScript.partPickedUp == true)
            {
                managerScript.partReturned = true;
            }
        }
    }

}
