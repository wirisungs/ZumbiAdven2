using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawningEnemy();
    }

    private void SpawningEnemy()
    {
        Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
    }
}
