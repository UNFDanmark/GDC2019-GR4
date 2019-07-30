using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleScript : MonoBehaviour
{
    public AudioClip impactSound;
    

    GameManagerScript managerScript;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {

        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(impactSound);   
            managerScript.isDead = true;
            Destroy(collision.gameObject);

        }
        
    }
}
