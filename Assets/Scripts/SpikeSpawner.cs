using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    float lengthZ;
    float widthX;
    public int numberOfSegments; //Amount of segments to divide level into
    public int obstaclesPerSegment; // Obstacles to spawn per segment
    public GameObject ground;
    private float xRotation;

    void Start()
    {
        SpawnObstacles();
        
    }

    void SpawnObstacles()
    {
        lengthZ = ground.transform.localScale.z;
        widthX = ground.transform.localScale.x;

        float segmentLength = lengthZ / numberOfSegments;

        for (int i = 0; i < numberOfSegments; i++)
        {
            for (int j = 0; j < obstaclesPerSegment; j++)
            {
                
                float segmentStartZ = i * segmentLength;

                
                float randomZ = Random.Range(segmentStartZ, segmentStartZ + segmentLength);
                float randomX = Random.Range(-widthX / 2, widthX / 2);
                float randomY = Random.Range(0, 2f);

                
                
                if (transform.position.y > 4)
                {
                    xRotation = -90;
                    
                }
                else
                {
                    xRotation = 90;
                    randomY *= -1f;
                }
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y + randomY, randomZ - lengthZ * 0.5f);

                Quaternion spawnRotation = Quaternion.Euler(-xRotation, 0, 0);
                Instantiate(obstaclePrefab, spawnPosition, spawnRotation);
            }
        }
    }
}