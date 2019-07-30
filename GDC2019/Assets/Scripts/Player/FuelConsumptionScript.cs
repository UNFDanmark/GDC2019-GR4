using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelConsumptionScript : MonoBehaviour
{
    public float maximumFuel = 100;   
    public int consumptionRate = 5;
    public Slider fuelBar;

    public float currentFuel = 0;
    AudioSource aSource;
    int consumptionCounter = 0;
    float timeSinceSound;
    float lowFuel = 30;
    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maximumFuel;
        lowFuel = maximumFuel / 5;
        consumptionCounter = 0;
        aSource = GetComponent<AudioSource>();
        fuelBar.value = CalculateFuel();
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
            if (aSource.isPlaying == false)
            {
                aSource.Play();
            }
        }
        
    }
    float CalculateFuel()
    {
        return currentFuel / maximumFuel;
    }

    public void ConsumeFuel()
    {
        consumptionCounter++;
        if (consumptionCounter == consumptionRate)
        {
            currentFuel--;
            consumptionCounter = 0;
            fuelBar.value = CalculateFuel();
        }

        
        
    }
}
