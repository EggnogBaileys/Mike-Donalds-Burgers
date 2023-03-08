using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PAHitbox : MonoBehaviour
{
    public GameObject enemy;

    EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == enemy)
        {
            enemyHealth.health--;
        }
    }

}
