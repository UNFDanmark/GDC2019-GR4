using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePartScript : MonoBehaviour
{
    GameManagerScript managerScript;
    private void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            managerScript.partPickedUp = true;
            gameObject.SetActive(false);
        }
    }
}
