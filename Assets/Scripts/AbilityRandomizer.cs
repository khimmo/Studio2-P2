using System.Collections.Generic;
using UnityEngine;

public class AbilityRandomizer : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public RectTransform[] spawnPositions;

    PlayerPowerups powerups;

    private int p, p0, p1, p2;


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
        if (other.CompareTag("Player"))
        {
            GetRandomPowerUps(3);
            Destroy(gameObject);
            powerups = other.GetComponent<PlayerPowerups>();
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
            int rnd = Random.Range(0, i);
            PowerUp value = allChoices[rnd];
            allChoices[rnd] = allChoices[i];
            allChoices[i] = value;
        }

        if (allChoices[0] == PowerUp.ReduceSize)
        {
            p0 = 3;
        }

        else if (allChoices[0] == PowerUp.ShootProjectile)
        {
            p0 = 2;
        }

        else if (allChoices[0] == PowerUp.GhostAbility)
        {
            p0 = 1;
        }

        else if (allChoices[0] == PowerUp.ExtraLife)
        {
            p0 = 0;
        }

        else if (allChoices[0] == PowerUp.SlowMotion)
        {
            p0 = 4;
        }

        //***************************************************//

        if (allChoices[1] == PowerUp.ReduceSize)
        {
            p1 = 3;
        }

        else if (allChoices[1] == PowerUp.ShootProjectile)
        {
            p1 = 2;
        }

        else if (allChoices[1] == PowerUp.GhostAbility)
        {
            p1 = 1;
        }

        else if (allChoices[1] == PowerUp.ExtraLife)
        {
            p1 = 0;
        }

        else if (allChoices[1] == PowerUp.SlowMotion)
        {
            p1 = 4;
        }

        //***************************************************//

        if (allChoices[2] == PowerUp.ReduceSize)
        {
            p2 = 3;
        }

        else if (allChoices[2] == PowerUp.ShootProjectile)
        {
            p2 = 2;
        }

        else if (allChoices[2] == PowerUp.GhostAbility)
        {
            p2 = 1;
        }

        else if (allChoices[2] == PowerUp.ExtraLife)
        {
            p2 = 0;
        }

        else if (allChoices[2] == PowerUp.SlowMotion)
        {
            p2 = 4;
        }

        Debug.Log(allChoices[0]);


        return allChoices.GetRange(0, numChoices);

        

        //Needs UI logic to display the 3 random choices to the player and allow them to choose one
        //Logic for player selection is in the ApplyPowerup() method
    }

   
    public void SpawnThreeRandomObjectsOnCanvas()
    {

        //ShuffleArray(objectsToSpawn);
        //ShuffleArray(spawnPositions);

        for (int i = 0; i < 3; i++)
        {
            //GameObject objectToSpawn = objectsToSpawn[i];
            RectTransform spawnPosition = spawnPositions[i];

            if (i == 0)
            {
                p = p0;
            }

            if (i == 1)
            {
                p = p1;
            }

            if (i == 2)
            {
                p = p2;
            }

            


            GameObject spawnedObject = Instantiate(objectsToSpawn[p], spawnPosition.position, Quaternion.identity, spawnPosition);


        }
    }


    private void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
