using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndToken : MonoBehaviour
{

    PlayerPowerups powerups;
    public GameObject powerupUI;
    AbilityRandomizer randomizer;

    public bool isTakeable;
    private int numberOfPowerups = 3;

    public GameObject backWallObject;
    BackWall backWall;

    private void Start()
    {
        randomizer = powerupUI.GetComponent<AbilityRandomizer>();
        isTakeable = true;
        backWall = backWallObject.GetComponent<BackWall>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isTakeable == true)
        {

            randomizer.GetRandomPowerUps(numberOfPowerups);
            randomizer.canUpgrade = true;
            randomizer.SpawnThreeRandomObjectsOnCanvas();

            isTakeable = false;

            if (backWall.currentLevel == (backWall.maxLevel - 1))
            {
                Destroy(gameObject);
            }

        }
    }
}



