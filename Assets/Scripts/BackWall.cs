using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWall : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    public GameObject ceiling;

    SpikeSpawner spawnerGround;
    SpikeSpawner spawnerCeiling;

    private Vector3 playerStartPosition;

    public int currentLevel;

    void Start()
    {
        playerStartPosition = player.transform.position;

        spawnerGround = ground.GetComponent<SpikeSpawner>();
        spawnerCeiling = ceiling.GetComponent<SpikeSpawner>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            IncreaseLevel();
        }
    }

    public void IncreaseLevel()
    {
        currentLevel++;

        if (currentLevel % 3 == 0)
        {
           
            spawnerCeiling.obstaclesPerSegment += 1;
            spawnerGround.obstaclesPerSegment += 1;
        }

        else
        {
            spawnerCeiling.numberOfSegments += 1;
            spawnerGround.numberOfSegments += 1;
        }

        player.transform.position = playerStartPosition;

        spawnerGround.DestroyAllObstacles();
        spawnerCeiling.DestroyAllObstacles();

        spawnerGround.SpawnObstacles();
        spawnerCeiling.SpawnObstacles();


    }
}
