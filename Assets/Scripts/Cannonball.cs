using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private Vector3 targetPosition;

    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;
    }

    private void Update()
    {
        if (targetPosition == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < 0.1f)
        {
            // Apply damage to the enemy ship
            Destroy(gameObject);
        }
    }
}

