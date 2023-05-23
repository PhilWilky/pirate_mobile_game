using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public Transform cannonballSpawnPoint;
    public float fireRate = 2f;

    private float fireTimer = 0f;
    private int currentCannons = 1;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && currentCannons > 0 && fireTimer >= 1f / fireRate)
        {
            FireCannonball();
            currentCannons--;
            fireTimer = 0f;
        }
    }

    private void FireCannonball()
    {
        if (cannonballPrefab != null)
        {
            GameObject cannonballGO = Instantiate(cannonballPrefab, cannonballSpawnPoint.position, Quaternion.identity);
            Cannonball cannonball = cannonballGO.GetComponent<Cannonball>();

            if (cannonball != null)
            {
                Vector3 targetPosition = CalculateTargetPosition(); // Call your custom method to calculate the target position
                cannonball.SetTargetPosition(targetPosition);
            }
        }
    }

    private Vector3 CalculateTargetPosition()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 cannonballSpawnPointPosition = cannonballSpawnPoint.position;
        Vector3 nearestEnemyPosition = Vector3.zero;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(cannonballSpawnPointPosition, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemyPosition = enemy.transform.position;
            }
        }

        return nearestEnemyPosition;
    }

}
