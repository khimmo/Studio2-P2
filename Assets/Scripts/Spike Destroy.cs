using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

         
    }
}
