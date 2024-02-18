using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint1, shootPoint2, shootPoint3;
    public int projectileCount = 0;

    public float sizeReductionPercent = 75f;

    public float ghostModeDuration = 2f;
    private bool isGhostModeActive = false;
    private Collider playerCollider;
    public int collisionCounter;
    public Material normalMaterial;
    public Material ghostMaterial;
    private Renderer playerRenderer;
    private int ghostModeUses = 0;

    public float slowMotionFactor = 3f;
    public float slowMotionDuration = 5f;
    public int slowMotionUses = 0;

    void Start()
    {
        playerCollider = GetComponent<Collider>();
        collisionCounter = 0;

        playerRenderer = GetComponent<Renderer>();

        projectileCount = 0;
        
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && projectileCount > 0)
        {
            ShootProjectile();
        }

        if (Input.GetKeyDown(KeyCode.E) && !isGhostModeActive && ghostModeUses > 0)
        {
            StartCoroutine(ActivateGhostMode());
        }

        if (Input.GetKeyDown(KeyCode.Q) && slowMotionUses > 0)
        {
            StartCoroutine(ActivateSlowMotion());
        }
    }

    public void AddProjectiles(int count)
    {
        projectileCount += count;
    }

    void ShootProjectile()
    {
        Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);

        if (projectileCount <= 0) return;

        
        GameObject projectile1 = Instantiate(projectilePrefab, shootPoint1.position, spawnRotation);
        Rigidbody rb1 = projectile1.GetComponent<Rigidbody>();
        
        rb1.velocity = transform.forward * 50f;

        GameObject projectile2 = Instantiate(projectilePrefab, shootPoint2.position, spawnRotation);
        Rigidbody rb2 = projectile2.GetComponent<Rigidbody>();

        rb2.velocity = transform.forward * 50f;

        GameObject projectile3 = Instantiate(projectilePrefab, shootPoint3.position, spawnRotation);
        Rigidbody rb3 = projectile3.GetComponent<Rigidbody>();

        rb3.velocity = transform.forward * 50f;

        projectileCount--;
    }

    
    public void AcquireShootingPowerUp()
    {
        AddProjectiles(3);
    }

    public void ReducePlayerSize()
    {
        
        transform.localScale *= sizeReductionPercent;
    }

    IEnumerator ActivateGhostMode()
    {
        isGhostModeActive = true;

        ghostModeUses--;

        if (playerRenderer != null)
        {
            playerRenderer.material = ghostMaterial;
        }

        
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), true);

        yield return new WaitForSeconds(ghostModeDuration);

        
        while (IsPlayerCollidingWithObstacle())
        {
            yield return null;
        }

        
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), false);

        isGhostModeActive = false;

        if (playerRenderer != null)
        {
            playerRenderer.material = normalMaterial;
        }
        
    }

    IEnumerator ActivateSlowMotion()
    {
        slowMotionUses--; // Decrement uses
        Time.timeScale = 1f / slowMotionFactor; // Slow down time
        yield return new WaitForSecondsRealtime(slowMotionDuration); // Wait for the duration in real time
        Time.timeScale = 1f; // Revert time scale to normal
    }

    public void AddSlowMotionUse()
    {
        slowMotionUses++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            collisionCounter++;
            Debug.Log("ENTER");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            collisionCounter--;
            if (collisionCounter < 0) collisionCounter = 0;
            Debug.Log("EXIT");
        }
    }

    private bool IsPlayerCollidingWithObstacle()
    {
        return collisionCounter > 0;
    }

    public void AddGhostModeUse()
    {
        ghostModeUses++;
    }
}
