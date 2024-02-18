using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWall : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    public GameObject ceiling;
    public GameObject Token;

    SpikeSpawner spawnerGround;
    SpikeSpawner spawnerCeiling;

    EndToken endToken;

    private Vector3 playerStartPosition;

    public int currentLevel;

    void Start()
    {
        playerStartPosition = player.transform.position;

        spawnerGround = ground.GetComponent<SpikeSpawner>();
        spawnerCeiling = ceiling.GetComponent<SpikeSpawner>();

        endToken = Token.GetComponent<EndToken>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            IncreaseLevel();
            endToken.isTakeable = true;
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
