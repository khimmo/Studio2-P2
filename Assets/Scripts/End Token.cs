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

    private void Start()
    {
        randomizer = powerupUI.GetComponent<AbilityRandomizer>();
        isTakeable = true;
    }

    public enum PowerUp
    {
        ReduceSize,
        ShootProjectile,
        GhostAbility,
        ExtraLife,
        SlowMotion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isTakeable == true)
        {
            GetRandomPowerUps(3);
            //Destroy(gameObject);
            powerups = other.GetComponent<PlayerPowerups>();

            randomizer.GetRandomPowerUps(numberOfPowerups);
            randomizer.SpawnThreeRandomObjectsOnCanvas();
            randomizer.canUpgrade = true;
            isTakeable = false;
        }
            

        
    }
    public List<PowerUp> GetRandomPowerUps(int numChoices)
    {
        List<PowerUp> allChoices = new List<PowerUp>
        {
            PowerUp.ReduceSize,
            PowerUp.ShootProjectile,
            PowerUp.GhostAbility,
            PowerUp.ExtraLife,
            PowerUp.SlowMotion
        };

        // Shuffle the list
        int n = allChoices.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);
            PowerUp value = allChoices[rnd];
            allChoices[rnd] = allChoices[i];
            allChoices[i] = value;
        }

        
        return allChoices.GetRange(0, numChoices);

        //Needs UI logic to display the 3 random choices to the player and allow them to choose one
        //Logic for player selection is in the ApplyPowerup() method
    }

    public void ApplyPowerUp(PowerUp selectedPowerUp)
    {

        //Powerup logic is still missing, will be added later

        switch (selectedPowerUp)
        {
            case PowerUp.ReduceSize:

                powerups.ReducePlayerSize();

                break;
            case PowerUp.ShootProjectile:

                powerups.AddProjectiles(3);

                break;
            case PowerUp.GhostAbility:

                powerups.AddGhostModeUse();

                break;
            case PowerUp.ExtraLife:

                // Respawn the player back at the starting position without losing health

                break;
            case PowerUp.SlowMotion:

                // Give the player the ability to slow down time for 5s

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
