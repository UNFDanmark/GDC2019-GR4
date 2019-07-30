using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePartScript : MonoBehaviour
{
    public GameManagerScript managerScript;
    public AudioClip pickupSound;
    public GameObject partLight;
    private void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    private void Update()
    {
        //partLight.GetComponent<Light>().intensity
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            managerScript.partPickedUp = true;
            managerScript.spaceshipLight.SetActive(true);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            gameObject.SetActive(false);
        }

    }
}
