using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int maxLevel;

    void Start()
    {
        playerStartPosition = player.transform.position;

        spawnerGround = ground.GetComponent<SpikeSpawner>();
        spawnerCeiling = ceiling.GetComponent<SpikeSpawner>();

        endToken = Token.GetComponent<EndToken>();
        currentLevel = 1;
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

        if (currentLevel > maxLevel)
        {
            SceneManager.LoadScene("Win");
        }

        else
        {
            player.transform.position = playerStartPosition;
        }

        if (currentLevel % 3 == 0)
        {
           
            spawnerCeiling.obstaclesPerSegment += 1;
            spawnerGround.obstaclesPerSegment += 1;
        }

        else
        {
            spawnerCeiling.numberOfSegments += 2;
            spawnerGround.numberOfSegments += 2;
        }

        

        spawnerGround.DestroyAllObstacles();
        spawnerCeiling.DestroyAllObstacles();

        spawnerGround.SpawnObstacles();
        spawnerCeiling.SpawnObstacles();


    }
}
