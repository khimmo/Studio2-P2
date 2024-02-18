using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
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
    }

    public void AddProjectiles(int count)
    {
        projectileCount += count;
    }

    void ShootProjectile()
    {
        if (projectileCount <= 0) return;

        
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        
        rb.velocity = transform.forward * 50f;

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
