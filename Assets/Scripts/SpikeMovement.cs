using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float bobbingSpeed = 5f; // Speed of the bobbing
    public float bobbingHeight = 0.5f; // Height of the bobbing
    private bool isBobbing = false; // Whether the spike should bob
    private Vector3 startPosition;
    private int direction;

    void Start()
    {
        startPosition = transform.position;

        // Determine if this spike should bob
        if (Random.Range(0, 100) < 25) // 25% chance
        {
            isBobbing = true;
        }

        if (transform.position.y > 4)
        {
            direction = -1;
        }

        else if (transform.position.y < 4)
        {
            direction = 1;
        }
    }

    void Update()
    {
        if (isBobbing)
        {
            // Calculate the new Y position using a sine wave
            float newY = startPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
            transform.position = new Vector3(startPosition.x, newY + (2f * direction), startPosition.z);
        }
    }
}
