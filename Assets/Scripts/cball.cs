using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cball : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody selfRb;
    public GameObject enemyObj;

    void Start()
    {
        selfRb = GetComponent<Rigidbody>(); //find the rigidbody component on the same object the script is on
        enemyObj = GameObject.Find("Enemy"); // finds the player game object by looking for its inspector name
    }

    void Update()
    {
        if (enemyObj != null)
        {
            Vector3 lookDirection = (enemyObj.transform.position - transform.position).normalized;

            // enemy chases player object
            selfRb.AddForce(lookDirection * speed);
        }

    }

    public void EnemyHit(Collision enemyColl)
    {
        Destroy(enemyColl.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(10); // Adjust the damage amount as needed
            }

            Destroy(gameObject);

        }

    }
}
