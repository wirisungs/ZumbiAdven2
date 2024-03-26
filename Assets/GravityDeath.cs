using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDeath : MonoBehaviour
{
    [SerializeField] private float damage = 99;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().TakeDamage(damage);
        }
    }
}
