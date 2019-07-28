﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuelConsumptionScript : MonoBehaviour
{
    public int maximumFuel = 100;   
    public int consumptionRate = 5;
    public int lowFuel = 30;
    AudioSource aSource;

    public int currentFuel = 0;
    int consumptionCounter = 0;
    bool fuelWarning = false;
    float timeSinceSound;
    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maximumFuel;
        consumptionCounter = 0;
        fuelWarning = false;
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentFuel <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (currentFuel <= lowFuel)
        {
            fuelWarning = true;
            if (aSource.isPlaying == false)
            {
                aSource.Play();
            }
        }
    }

    public void ConsumeFuel()
    {
        consumptionCounter++;
        if (consumptionCounter == consumptionRate)
        {
            currentFuel--;
            consumptionCounter = 0;
        }
        
    }
}
