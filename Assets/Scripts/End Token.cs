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
        IncreaseMaxHealth
    }
    public List<PowerUp> GetRandomPowerUps(int numChoices)
    {
        List<PowerUp> allChoices = new List<PowerUp>
        {
            PowerUp.ReduceSize,
            PowerUp.ShootProjectile,
            PowerUp.GhostAbility,
            PowerUp.ExtraLife,
            PowerUp.IncreaseMaxHealth
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
                // Respawn the player back at the starting position
                break;
            case PowerUp.IncreaseMaxHealth:
                // Give the player extra health
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
