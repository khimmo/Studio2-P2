using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndToken : MonoBehaviour
{

    public enum PowerUp
    {
        ReduceSize,
        ShootProjectile,
        GhostAbility,
        ExtraLife,
        SlowMotion
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
                // Reduce player size by 25%
                break;
            case PowerUp.ShootProjectile:
                // Grant projectile shooting ability
                break;
            case PowerUp.GhostAbility:
                // Grant ghosting ability for 2 seconds
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
